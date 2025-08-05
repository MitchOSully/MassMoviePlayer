using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieGridPage : Page
    {
        public MovieGridPage()
        {
            InitializeComponent();
            LoadVideo();
        }

        private async void LoadVideo()
        {
            try
            {
                StorageFile file1 = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Vids/Balcony.mp4"));
                MediaPlayer1.Source = MediaSource.CreateFromStorageFile(file1);

                StorageFile file2 = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Vids/FF1Trailer.mp4"));
                MediaPlayer2.Source = MediaSource.CreateFromStorageFile(file2);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
