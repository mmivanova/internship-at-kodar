using System;
using System.Diagnostics;
using System.Windows.Forms;
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
            tbDisplay.Text = Executor.ExecuteNormal(pbLoader);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private void btnNormalParallelExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            tbDisplay.Text = Executor.ExecuteParallel(pbLoader);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private async void btnAsyncExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            tbDisplay.Text = await Executor.ExecuteAsync(pbLoader);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private async void btnParallelAsyncExecute_Click(object sender, EventArgs e)
        {
            ResetTextBoxAndProgressBar();

            _watch.Start();
            tbDisplay.Text = await Executor.ExecuteParallelAsync(pbLoader);
            _watch.Stop();

            tbDisplay.Text += $@"Total execution time: {_watch.ElapsedMilliseconds}ms";
        }

        private void ResetTextBoxAndProgressBar()
        {
            tbDisplay.Text = string.Empty;
            pbLoader.Value = 0;
            _watch.Reset();
        }
    }
}