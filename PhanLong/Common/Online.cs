using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhanLong.Common
{
    public class Online : Hub
    {
		
		private static int _userCount = 0;
		public override Task OnConnected()
		{
			_userCount++;
			var context = GlobalHost.ConnectionManager.GetHubContext<Online>();
			context.Clients.All.online(_userCount);

			return base.OnConnected();
		}
		public override Task OnReconnected()
		{
			_userCount++;
			var context = GlobalHost.ConnectionManager.GetHubContext<Online>();
			context.Clients.All.online(_userCount);
			return base.OnConnected();
		}
		public override Task OnDisconnected(bool stopCalled)
		{
			_userCount--;
			var context = GlobalHost.ConnectionManager.GetHubContext<Online>();
			context.Clients.All.online(_userCount);
			return base.OnDisconnected(stopCalled);

		}
	}
}