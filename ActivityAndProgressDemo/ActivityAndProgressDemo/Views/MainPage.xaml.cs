using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityAndProgressDemo.Views
{
    public partial class MainPage : ContentPage
    {
        bool isTaskRunning;
        float progress = 0f;

        public MainPage()
        {
            InitializeComponent();
            UpdateUiState();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            progress += 0.2f;

            if (progress > 1)
            {
                progress = 0;
            }

            // directly set the new progress value
            defaultProgressBar.Progress = progress;

            // animate to the new value over 750 milliseconds using Linear easing
            await styledProgressBar.ProgressTo(progress, 750, Easing.Linear);
        }
        void OnButtonClicked1(object sender, EventArgs e)
        {
            isTaskRunning = !isTaskRunning;
            UpdateUiState();
        }


        void UpdateUiState()
        {
            runningStatusLabel.Text = isTaskRunning ? "A task is in progress." : "All tasks complete!";
            defaultActivityIndicator.IsRunning = isTaskRunning;
            styledActivityIndicator.IsRunning = isTaskRunning;
        }

    }
}
