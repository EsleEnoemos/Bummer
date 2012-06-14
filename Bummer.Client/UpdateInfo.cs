using System;
using Bummer.Common;

namespace Bummer.Client {
	public class UpdateInfo : IUpdateInfo {
		public string UpdateInfoURL {
			get {
				return "http://bummer.someone-else.com:8000/Bummer.Client.xml";
			}
		}
	}
}
