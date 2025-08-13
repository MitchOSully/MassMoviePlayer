using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MassMoviePlayer
{
    public sealed partial class MovieGridPage : Page
    {
        public ObservableCollection<Models.Video> videoList { get; set; } = new ObservableCollection<Models.Video>();

        public MovieGridPage()
        {
            InitializeComponent();
            LoadVideo();
            RefreshGridLayout();
        }

        private async void LoadVideo()
        {
            try
            {
                Models.Video? vid = await Models.Video.CreateVideo(new Uri("ms-appx:///Assets/Vids/FF1Trailer.mp4"));
                if (vid != null)
                {
                    videoList.Add(vid);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async void AddVideoClick(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".wmv");
            picker.FileTypeFilter.Add(".avi");

            IntPtr hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                videoList.Add(new Models.Video(MediaSource.CreateFromStorageFile(file)));
            }
        }

        private void RefreshGridLayout()
        {
            const float aspectRatio = 16f / 9f; // 16:9 aspect ratio

            videoGridLayout.MaximumRowsOrColumns = 4;
            videoGridLayout.MinItemWidth = 400;
            videoGridLayout.MinItemHeight = videoGridLayout.MinItemWidth / aspectRatio;
        }
    }
}
