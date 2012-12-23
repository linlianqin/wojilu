﻿using System;
using System.Collections.Generic;
using System.Text;
using wojilu.Web.Mvc;
using System.IO;
using wojilu.Web.Context;
using wojilu.Apps.Content.Domain;
using wojilu.Web.Controller.Content.Section;
using wojilu.DI;

namespace wojilu.Web.Controller.Content.Caching.Actions {

    public class PostAddObserver : ActionObserver {

        private static readonly ILog logger = LogManager.GetLogger( typeof( PostAddObserver ) );

        public override void ObserveActions() {

            Admin.Common.PostController post = new wojilu.Web.Controller.Content.Admin.Common.PostController();
            observe( post.Create );
            observe( post.SaveAdmin );

            Admin.Section.TalkController talk = new wojilu.Web.Controller.Content.Admin.Section.TalkController();
            observe( talk.Create );

            Admin.Section.TextController txt = new wojilu.Web.Controller.Content.Admin.Section.TextController();
            observe( txt.Create );

            Admin.Section.VideoController video = new wojilu.Web.Controller.Content.Admin.Section.VideoController();
            observe( video.Create );

            Admin.Section.ImgController img = new wojilu.Web.Controller.Content.Admin.Section.ImgController();
            observe( img.CreateListInfo );
            observe( img.CreateImgList );
            observe( img.SetLogo );
            observe( img.UpdateListInfo );
            observe( img.DeleteImg );

            Admin.Common.PollController poll = new wojilu.Web.Controller.Content.Admin.Common.PollController();
            observe( poll.Create );
        }

        public override void AfterAction( Context.MvcContext ctx ) {

            new HomeMaker().Process( ctx );
            logger.Info( "----------------make home done-----------------" );

            new DetailMaker().Process( ctx );

            new ListMaker().Process( ctx );

        }


    }

}