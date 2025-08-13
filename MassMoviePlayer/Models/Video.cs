using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Storage;

namespace MassMoviePlayer.Models
{
    public class Video
    {
        public MediaSource source;

        public Video(MediaSource inSource)
        {
            source = inSource;
        }

        public static async Task<Video?> CreateVideo(Uri uriPath)
        {
            Video? vid = null;
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uriPath);
                vid = new Video(MediaSource.CreateFromStorageFile(file));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return vid;
        }
        public static async Task<Video?> CreateVideo(string path)
        {
            Video? vid = null;
            try
            {
                StorageFile file = await StorageFile.GetFileFromPathAsync(path);
                vid = new Video(MediaSource.CreateFromStorageFile(file));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return vid;
        }
    }
}
