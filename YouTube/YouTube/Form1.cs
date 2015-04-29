using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using YouTube_Downloader;


namespace YouTube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        public void btnGet_Click(object sender, EventArgs e)
        {
            string url = this.txtURL.Text;
            string[] videoURLs;
            
            try
            {
                videoURLs = new string[1];
                videoURLs[0] = txtURL.Text;
//                List<YouTubeVideoQuality> urls = YouTubeVideoDownloader.GetYouTubeVideoUrls(videoURLs);
                List<YouTube_Downloader.YouTubeVideoQuality> urls = YouTubeDownloader.GetYouTubeVideoUrls(videoURLs);
                
                cbxQuality.Items.Clear();

                foreach (var items in urls)
                {
                    cbxQuality.Items.Add(items);
                    string videoTitle = items.VideoTitle;
                    txtTitle.Text = videoTitle;

                    
                }
                this.btnDownload.Enabled = true;

            }
            catch
            {
                this.btnDownload.Enabled = true;
                MessageBox.Show("Load Failed!");
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            YouTubeVideoQuality tempItem = (YouTubeVideoQuality)cbxQuality.SelectedItem;
            saveFileDialog1.FileName = tempItem.VideoTitle +"."+ tempItem.Extention;
            saveFileDialog1.ShowDialog();
            string folder = Path.GetDirectoryName(saveFileDialog1.FileName);
            string file = Path.GetFileName(saveFileDialog1.FileName);
            FileDownloader downloader = new FileDownloader(tempItem.DownloadUrl, folder, file);
            downloader.ProgressChanged += this.OnRunWorkerProgress;
            downloader.RunWorkerCompleted += OnRunWorkerCompleted;
            downloader.RunWorkerAsync();
        }


        private void OnRunWorkerCompleted(Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Completed");
        }

        private void OnRunWorkerProgress(Object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
