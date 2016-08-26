using System;
using System.Linq;
using XamarinCordova.iOS.Binding;
using UIKit;
using Foundation;

namespace XamarinCordova.iOS.Example
{
    public partial class ViewController : UIViewController
    {
        private CDVViewController _cdv;

        protected ViewController (IntPtr handle) : base (handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            var samplePlugin = new sample();
            _cdv = new CDVViewController ();
            _cdv.Init();

            //_cdv.CommandDelegate = new CDVCommandDelegateImpl(_cdv);
            _cdv.RegisterPluginClassName(samplePlugin, "sample");
            _cdv.WwwFolderName = "www";
            _cdv.StartPage = "index.html";

            var constraints = new [] { NSLayoutAttribute.Top, NSLayoutAttribute.Bottom, NSLayoutAttribute.Left, NSLayoutAttribute.Right }
                .Select(attr => NSLayoutConstraint.Create(_cdv.View, attr, NSLayoutRelation.Equal, View, attr, 1, 0)).ToArray();


            var maps = _cdv.PluginsMap;
            var mapDic = new NSMutableDictionary(maps);
            mapDic.Add((NSString)"sample", (NSString)"sample");

            _cdv.PluginsMap = mapDic;

            var demo = _cdv.PluginObjects;
            //demo.Add((NSString)"sample", (NSString)"sample");

            demo.Add((NSString)"sample", samplePlugin);
            samplePlugin.PluginInitialize();
            samplePlugin.CommandDelegate = _cdv.CommandDelegate;
   

            Add(_cdv.View);
            View.AddConstraints(constraints);

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    //[Export(typeof(CDVPlugin))]
    [Register("sample")]
    public class sample : CDVPlugin
    {
        [Export("SayHello:command")]
        public void SayHello(CDVInvokedUrlCommand command)
        {
            string commandParam = string.Empty;
            if (command.Arguments.Any())
            {
                commandParam = command.Arguments.First();
            }

            var res = CDVPluginResult.ResultWithStatusMessagesArray(CDVCommandStatus.Ok, (NSString)"Hello", (NSString)commandParam);

            //CommandDelegate.SendPluginResult(res, command.CallbackId);
            // ---> Cannot use the commandDelegate. It is null and crashes. 
            var cdvVC = (CDVViewController)ViewController;
            var myNewCmd = new CDVCommandDelegateImpl(cdvVC);
            myNewCmd.SendPluginResult(res, command.CallbackId);
        }
    }
}

