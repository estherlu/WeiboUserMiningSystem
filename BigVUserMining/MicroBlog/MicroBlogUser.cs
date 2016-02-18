using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebYQCrawling.MicroBlog
{
    public class MicroBlogUser
    {
        private string microBlogUserID;   //用户ID号

        public string MicroBlogUserID
        {
            get { return microBlogUserID; }
            set { microBlogUserID = value; }
        }

        public string microBlogUserName;

        public string MicroBlogUserName
        {
            get { return microBlogUserName; }
            set { microBlogUserName = value; }
        }

        public string microBlogUserScreenName;

        public string MicroBlogUserScreenName
        {
            get { return microBlogUserScreenName; }
            set { microBlogUserScreenName = value; }
        }

        public string microBlogUserSex;

        public string MicroBlogUserSex
        {
            get { return microBlogUserSex; }
            set { microBlogUserSex = value; }
        }

        public string microBlogLocation;

        public string MicroBlogLocation
        {
            get { return microBlogLocation; }
            set { microBlogLocation = value; }
        }

        public string microBlogUserDescription;

        public string MicroBlogUserDescription
        {
            get { return microBlogUserDescription; }
            set { microBlogUserDescription = value; }
        }

        public string microBlogUserFriendsCount;

        public string MicroBlogUserFriendsCount
        {
            get { return microBlogUserFriendsCount; }
            set { microBlogUserFriendsCount = value; }
        }

        public string microBlogUserFollowerCount;

        public string MicroBlogUserFollowerCount
        {
            get { return microBlogUserFollowerCount; }
            set { microBlogUserFollowerCount = value; }
        }

        public string microBlogMsgCount;

        public string MicroBlogMsgCount
        {
            get { return microBlogMsgCount; }
            set { microBlogMsgCount = value; }
        }

        public string microBlogUserCreateTime;

        public string MicroBlogUserCreateTime
        {
            get { return microBlogUserCreateTime; }
            set { microBlogUserCreateTime = value; }
        }



    }
}
