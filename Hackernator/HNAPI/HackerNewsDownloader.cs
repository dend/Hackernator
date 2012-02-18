using System;
using System.Collections.Generic;
using Hackernator.Models;
using System.Net;
using System.IO;
namespace Hackernator.HNAPI
{
    public class HackerNewsDownloader
    {
        private Action<string> onRawDownloadCompleted;

        public void DownloadRawFrontPage(Action<string> onRawDownload)
        {
            onRawDownloadCompleted = onRawDownload;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HackerNewsUrls.FrontPage);
            request.BeginGetResponse(new AsyncCallback(RawDownloadCompleted), request);
        }

        private void RawDownloadCompleted(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);

            string data = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                data = reader.ReadToEnd();
            }
            onRawDownloadCompleted(data);
        }
    }
}
