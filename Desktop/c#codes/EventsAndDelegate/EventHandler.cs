namespace EventsAndDelegate
{
	public delegate void DownloadFile(object source, CustomArgs args);
	public class EventHandler
	{
		public  event DownloadFile OnDownloaded;
		public void DownloadFile()
		
		{
			OnDownloaded.Invoke(this, new CustomArgs{Name = "ade", Email = "ade@gmail.com"});
			// OnDownloadedEvent();
		}
		protected virtual void OnDownloadedEvent()
		
		{
			OnDownloaded.Invoke(this,new CustomArgs{Name = "ade", Email = "ade@gmail.com"} );
		}
	}
}