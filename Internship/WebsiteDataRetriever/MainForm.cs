using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using WebsiteDataRetriever.Data;
using WebsiteDataRetriever.Helpers;

namespace WebsiteDataRetriever
{
    public partial class MainForm : Form
    {
        private readonly Stopwatch _watch = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNormalExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            var websites = Executor.ExecuteNormal();
            DisplayDataOnFrom(websites);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private void btnNormalParallelExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            var websites = Executor.ExecuteParallel();
            DisplayDataOnFrom(websites);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private async void btnAsyncExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            var websites = await Executor.ExecuteAsync();
            DisplayDataOnFrom(websites);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private async void btnParallelAsyncExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            var websites = await Executor.ExecuteParallelAsync();
            DisplayDataOnFrom(websites);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private void ResetTextBoxAndProgressBar()
        {
            tbDisplay.Text = string.Empty;
            pbLoader.Value = 0;
            _watch.Reset();
        }
        
        private void DisplayDataOnFrom(List<Website> websites)
        {
            tbDisplay.Text = string.Empty;
            foreach (var website in websites)
            {
                tbDisplay.Text += WriteWebsiteData(website);
            }
        }

        private static string WriteWebsiteData(Website website)
        {
            return
                $@"{website.WebsiteUrl} downloaded: {website.WebsiteData.Length} characters long {Environment.NewLine}";
        }
    }
}