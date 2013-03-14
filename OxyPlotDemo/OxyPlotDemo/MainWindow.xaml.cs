using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace OxyPlotDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModels.MainWindowModel viewModel;

        public MainWindow()
        {
            viewModel = new ViewModels.MainWindowModel();
            DataContext = viewModel;

            CompositionTarget.Rendering += CompositionTargetRendering;
            stopwatch.Start();

            InitializeComponent();
        }

        private long frameCounter;
        private System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
        private long lastUpdateMilliSeconds;

        private void CompositionTargetRendering(object sender, EventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > lastUpdateMilliSeconds + 5000)
            {
                viewModel.UpdateModel();
                Plot1.RefreshPlot(true);
                lastUpdateMilliSeconds = stopwatch.ElapsedMilliseconds;
            }
        }





    }
}
