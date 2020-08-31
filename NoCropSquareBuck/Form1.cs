using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NoCropSquareBuck
{
    public partial class Form1 : Form
    {
        private readonly Form1 _self;
        public Form1()
        {
            _self = this;
            InitializeComponent();
            lblSrc.Text = "";
            lblDst.Text = "";
            _exifHandler = new ExifHandlerMicrosoft();
            _backColor = Color.White;
            lblBackColor.Text = _backColor.Name;
        }

        private IExifHandler _exifHandler;
        private Color _backColor;
        private string _src;
        private string _dst;
        /// <summary>
        /// used to select parent folder when click on open destination dialog, right after processing a folder,
        /// Allow to easily create NewFolder, otherwise the folder will be create inside the last processed folder
        /// </summary>
        private string _preProcessDst; 

        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK) return;

            _src=folderBrowserDialog1.SelectedPath;
            lblSrc.Text = _src;

            progressBar1.Value = 0;
        }

        private void btnDst_Click(object sender, EventArgs e)
        {
            //To ease folder creation inside a same directory (after performing processing once, to create folder beside last one)
            if (!string.IsNullOrWhiteSpace(_preProcessDst))
            {
                folderBrowserDialog2.SelectedPath = Utility.GetParentDirectoryOrCurrent(_preProcessDst);
                _preProcessDst = null;
            }

            if (folderBrowserDialog2.ShowDialog(this) != DialogResult.OK) return;

            _dst = folderBrowserDialog2.SelectedPath;
            lblDst.Text = _dst;

            progressBar1.Value = 0;
        }

        private void btnNoCrop_Click(object sender, EventArgs e)
        {
            string pathError="Requested path is invalid.";
            if (string.IsNullOrWhiteSpace(_src) || !Directory.Exists(_src))
            {
                pathError = "Source directory does not exists";
            }
            else if (string.IsNullOrWhiteSpace(_dst))
            {
                pathError = "Destination directory does not exists";
            }
            else if(!Directory.Exists(_dst))
            {
                Directory.CreateDirectory(_dst);
            }

            if (string.IsNullOrWhiteSpace(_src)
                || string.IsNullOrWhiteSpace(_dst)
                || !Directory.Exists(_src)
                || !Directory.Exists(_dst))
            {
                MessageBox.Show(pathError);
                return;
            }

            _preProcessDst = _dst;

            btnDst.Enabled = false;
            btnSrc.Enabled = false;
            btnNoCrop.Enabled = false;
            btnBackColor.Enabled = false;
            progressBar1.Value = 0;
            int current = 0;

            Thread t = new Thread(() =>
            {
                List<KeyValuePair<string,string>> errors = new List<KeyValuePair<string, string>>();
                try
                {
                    var files = Directory.GetFiles(_src);

                    foreach (var f in files)
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read))
                            {
                                using (Image iSrc = Image.FromStream(fs))
                                {
                                    Bitmap bSrc = (Bitmap) iSrc;

                                    int w = (bSrc.Width > bSrc.Height) ? bSrc.Width : bSrc.Height;
                                    int h = (bSrc.Width > bSrc.Height) ? bSrc.Width : bSrc.Height;

                                    //Check for exif data to determin orientation of camera when photo was taken and rotate to what's expected
                                    if (bSrc.PropertyIdList.Contains(0x112)) //0x112 = Orientation
                                    {
                                        var prop = bSrc.GetPropertyItem(0x112);
                                        if (prop.Type == 3 && prop.Len == 2)
                                        {
                                            UInt16 orientationExif =
                                                BitConverter.ToUInt16(bSrc.GetPropertyItem(0x112).Value, 0);
                                            if (orientationExif == 8)
                                            {
                                                bSrc.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                            }
                                            else if (orientationExif == 3)
                                            {
                                                bSrc.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                            }
                                            else if (orientationExif == 6)
                                            {
                                                bSrc.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                            }
                                        }
                                    }

                                    using (Bitmap bDest = new Bitmap(w, h))
                                    {
                                        using (var g = Graphics.FromImage(bDest))
                                        {
                                            g.Clear(_backColor);

                                            var remainedWidth = bDest.Width - bSrc.Width;
                                            var remainedHeight = bDest.Height - bSrc.Height;


                                            int leftPos = 0;
                                            int topPos = 0;

                                            if (remainedWidth != 0)
                                                leftPos = remainedWidth / 2;

                                            if (remainedHeight != 0)
                                                topPos = remainedHeight / 2;

                                            g.DrawImage(bSrc, leftPos, topPos, bSrc.Width, bSrc.Height);

                                            g.Flush();
                                        }

                                        var fileName = Path.GetFileName(f);
                                        var destLoc = Path.Combine(_dst, fileName);
                                        var data = _exifHandler.Read(bSrc);
                                        //TODO: Remove Exif that shouldn't get copied
                                        _exifHandler.Write(bDest, data);

                                        bDest.Save(destLoc, ImageFormat.Jpeg);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            errors.Add(new KeyValuePair<string, string>(f, ex.Message));
                        }
                        current++;
                        if (_self.InvokeRequired)
                        {
                            var current1 = current;
                            _self.Invoke(new Action(delegate
                            {
                                progressBar1.Value = (current1 > 0) ? (current1 * 100) / files.Length : 0;
                            }));
                        }
                        else
                        {
                            progressBar1.Value = (current > 0) ? (current * 100) / files.Length : 0;
                        }
                        GC.Collect();
                    }
                    if (_self.InvokeRequired)
                    {
                        _self.Invoke(new Action(delegate
                        {
                            progressBar1.Value = 100;
                        }));
                    }
                    else
                    {
                        progressBar1.Value = 100;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has been occur");
                }
                finally
                {
                    if (errors.Any())
                    {
                        string sErr = "";
                        foreach (var error in errors.GroupBy(g => g.Value))
                        {
                            sErr = "\n\r" + error.Key + "\n\r";
                            sErr += string.Join("\n\r", error.Select(s => s.Key));
                        }
                        MessageBox.Show("An Error Has Been Occur while processing files:" + sErr);
                    }

                    if (_self.InvokeRequired)
                    {
                        _self.Invoke(new Action(delegate
                        {
                            btnDst.Enabled = true;
                            btnSrc.Enabled = true;
                            btnNoCrop.Enabled = true;
                        }));
                    }
                    else
                    {
                        btnDst.Enabled = true;
                        btnSrc.Enabled = true;
                        btnNoCrop.Enabled = true;
                    }
                }
            });
            t.Start();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                lblBackColor.Text = colorDialog1.Color.Name;
                _backColor = colorDialog1.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

