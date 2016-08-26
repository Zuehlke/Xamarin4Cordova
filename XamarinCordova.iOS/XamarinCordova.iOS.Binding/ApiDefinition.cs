using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XamarinCordova.iOS.Binding
{

    // @protocol CDVWebViewEngineProtocol <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface CDVWebViewEngineProtocol
    {
        // @required @property (readonly, nonatomic, strong) UIView * engineWebView;
        [Export ("engineWebView", ArgumentSemantic.Strong)]
        UIView EngineWebView { get; }

        // @required -(id)loadRequest:(NSURLRequest *)request;
        [Abstract]
        [Export ("loadRequest:")]
        NSObject LoadRequest (NSUrlRequest request);

        // @required -(id)loadHTMLString:(NSString *)string baseURL:(NSURL *)baseURL;
        [Abstract]
        [Export ("loadHTMLString:baseURL:")]
        NSObject LoadHTMLString (string @string, NSUrl baseURL);

        // @required -(void)evaluateJavaScript:(NSString *)javaScriptString completionHandler:(void (^)(id, NSError *))completionHandler;
        [Abstract]
        [Export ("evaluateJavaScript:completionHandler:")]
        void EvaluateJavaScript (string javaScriptString, Action<NSObject, NSError> completionHandler);

        // @required -(NSURL *)URL;
        [Abstract]
        [Export ("URL")]
        NSUrl URL { get; }

        // @required -(BOOL)canLoadRequest:(NSURLRequest *)request;
        [Abstract]
        [Export ("canLoadRequest:")]
        bool CanLoadRequest (NSUrlRequest request);

        // @required -(instancetype)initWithFrame:(CGRect)frame;
        //[Abstract]
        [Export ("initWithFrame:")]
        IntPtr Constructor (CGRect frame);

        // @required -(void)updateWithInfo:(NSDictionary *)info;
        [Abstract]
        [Export ("updateWithInfo:")]
        void UpdateWithInfo (NSDictionary info);
    }

    // @protocol CDVScreenOrientationDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface CDVScreenOrientationDelegate
    {
        // @required -(NSUInteger)supportedInterfaceOrientations;
        [Abstract]
        [Export ("supportedInterfaceOrientations")]
        nuint SupportedInterfaceOrientations { get; }

        // @required -(BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation;
        [Abstract]
        [Export ("shouldAutorotateToInterfaceOrientation:")]
        bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation interfaceOrientation);

        // @required -(BOOL)shouldAutorotate;
        [Abstract]
        [Export ("shouldAutorotate")]
        bool ShouldAutorotate { get; }
    }

    // @interface CDVInvokedUrlCommand : NSObject
    [BaseType (typeof (NSObject))]
    public interface CDVInvokedUrlCommand
    {
        // @property (readonly, nonatomic) NSArray * arguments;
        [Export ("arguments")]
        //[Verify (StronglyTypedNSArray)]
        NSString [] Arguments { get; }

        // @property (readonly, nonatomic) NSString * callbackId;
        [Export ("callbackId")]
        string CallbackId { get; }

        // @property (readonly, nonatomic) NSString * className;
        [Export ("className")]
        string ClassName { get; }

        // @property (readonly, nonatomic) NSString * methodName;
        [Export ("methodName")]
        string MethodName { get; }

        // +(CDVInvokedUrlCommand *)commandFromJson:(NSArray *)jsonEntry;
        [Static]
        [Export ("commandFromJson:")]
        //[Verify (StronglyTypedNSArray)]
        CDVInvokedUrlCommand CommandFromJson (NSObject [] jsonEntry);

        // -(id)initWithArguments:(NSArray *)arguments callbackId:(NSString *)callbackId className:(NSString *)className methodName:(NSString *)methodName;
        [Export ("initWithArguments:callbackId:className:methodName:")]
        //[Verify (StronglyTypedNSArray)]
        IntPtr Constructor (NSObject [] arguments, string callbackId, string className, string methodName);

        // -(id)initFromJson:(NSArray *)jsonEntry;
        [Export ("initFromJson:")]
        //[Verify (StronglyTypedNSArray)]
        IntPtr Constructor (NSObject [] jsonEntry);

        // -(id)argumentAtIndex:(NSUInteger)index;
        [Export ("argumentAtIndex:")]
        NSObject ArgumentAtIndex (nuint index);

        // -(id)argumentAtIndex:(NSUInteger)index withDefault:(id)defaultValue;
        [Export ("argumentAtIndex:withDefault:")]
        NSObject ArgumentAtIndex (nuint index, NSObject defaultValue);

        // -(id)argumentAtIndex:(NSUInteger)index withDefault:(id)defaultValue andClass:(Class)aClass;
        [Export ("argumentAtIndex:withDefault:andClass:")]
        NSObject ArgumentAtIndex (nuint index, NSObject defaultValue, Class aClass);
    }

    // typedef NSURL * (^UrlTransformerBlock)(NSURL *);
    delegate NSUrl UrlTransformerBlock (NSUrl arg0);

    // @protocol CDVCommandDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface CDVCommandDelegate
    {
        // @required @property (readonly, nonatomic) NSDictionary * settings;
        [Export ("settings")]
        NSDictionary Settings { get; }

        // @required @property (copy, nonatomic) UrlTransformerBlock urlTransformer;
        [Export ("urlTransformer", ArgumentSemantic.Copy)]
        UrlTransformerBlock UrlTransformer { get; set; }

        // @required -(NSString *)pathForResource:(NSString *)resourcepath;
        [Abstract]
        [Export ("pathForResource:")]
        string PathForResource (string resourcepath);

        // @required -(id)getCommandInstance:(NSString *)pluginName;
        [Abstract]
        [Export ("getCommandInstance:")]
        NSObject GetCommandInstance (string pluginName);

        // @required -(void)sendPluginResult:(CDVPluginResult *)result callbackId:(NSString *)callbackId;
        [Abstract]
        [Export ("sendPluginResult:callbackId:")]
        void SendPluginResult (CDVPluginResult result, string callbackId);

        // @required -(void)evalJs:(NSString *)js;
        [Abstract]
        [Export ("evalJs:")]
        void EvalJs (string js);

        // @required -(void)evalJs:(NSString *)js scheduledOnRunLoop:(BOOL)scheduledOnRunLoop;
        [Abstract]
        [Export ("evalJs:scheduledOnRunLoop:")]
        void EvalJs (string js, bool scheduledOnRunLoop);

        // @required -(void)runInBackground:(void (^)())block;
        [Abstract]
        [Export ("runInBackground:")]
        void RunInBackground (Action block);

        // @required -(NSString *)userAgent;
        [Abstract]
        [Export ("userAgent")]
        string UserAgent { get; }
    }

    // @interface CDVCommandQueue : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVCommandQueue
    {
        // @property (readonly, nonatomic) BOOL currentlyExecuting;
        [Export ("currentlyExecuting")]
        bool CurrentlyExecuting { get; }

        // -(id)initWithViewController:(CDVViewController *)viewController;
        [Export ("initWithViewController:")]
        IntPtr Constructor (CDVViewController viewController);

        // -(void)dispose;
        [Export ("dispose")]
        void Dispose ();

        // -(void)resetRequestId;
        [Export ("resetRequestId")]
        void ResetRequestId ();

        // -(void)enqueueCommandBatch:(NSString *)batchJSON;
        [Export ("enqueueCommandBatch:")]
        void EnqueueCommandBatch (string batchJSON);

        // -(void)fetchCommandsFromJs;
        [Export ("fetchCommandsFromJs")]
        void FetchCommandsFromJs ();

        // -(void)executePending;
        [Export ("executePending")]
        void ExecutePending ();

        // -(BOOL)execute:(CDVInvokedUrlCommand *)command;
        [Export ("execute:")]
        bool Execute (CDVInvokedUrlCommand command);
    }

    // @interface CDVPluginResult : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVPluginResult
    {
        // @property (readonly, nonatomic, strong) NSNumber * status;
        [Export ("status", ArgumentSemantic.Strong)]
        NSNumber Status { get; }

        // @property (readonly, nonatomic, strong) id message;
        [Export ("message", ArgumentSemantic.Strong)]
        NSObject Message { get; }

        // @property (nonatomic, strong) NSNumber * keepCallback;
        [Export ("keepCallback", ArgumentSemantic.Strong)]
        NSNumber KeepCallback { get; set; }

        // @property (nonatomic, strong) id associatedObject;
        [Export ("associatedObject", ArgumentSemantic.Strong)]
        NSObject AssociatedObject { get; set; }

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal;
        [Static]
        [Export ("resultWithStatus:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsString:(NSString *)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsString:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, string theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsArray:(NSArray *)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsArray:")]
        //[Verify (StronglyTypedNSArray)]
        CDVPluginResult ResultWithStatusMessagesArray (CDVCommandStatus statusOrdinal, params NSString [] theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsInt:(int)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsInt:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, int theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsNSInteger:(NSInteger)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsNSInteger:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, nint theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsNSUInteger:(NSUInteger)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsNSUInteger:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, nuint theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsDouble:(double)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsDouble:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, double theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsBool:(BOOL)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsBool:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, bool theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsDictionary:(NSDictionary *)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsDictionary:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, NSDictionary theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsArrayBuffer:(NSData *)theMessage;
        [Static]
        [Export ("resultWithStatus:messageAsArrayBuffer:")]
        CDVPluginResult ResultWithStatus (CDVCommandStatus statusOrdinal, NSData theMessage);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageAsMultipart:(NSArray *)theMessages;
        [Static]
        [Export ("resultWithStatus:messageAsMultipart:")]
        //[Verify (StronglyTypedNSArray)]
        CDVPluginResult ResultWithStatusMessagesMultipart (CDVCommandStatus statusOrdinal, params NSString [] theMessages);

        // +(CDVPluginResult *)resultWithStatus:(CDVCommandStatus)statusOrdinal messageToErrorObject:(int)errorCode;
        [Static]
        [Export ("resultWithStatus:messageToErrorObject:")]
        CDVPluginResult ResultWithStatusErrorCode (CDVCommandStatus statusOrdinal, int errorCode);

        // +(void)setVerbose:(BOOL)verbose;
        [Static]
        [Export ("setVerbose:")]
        void SetVerbose (bool verbose);

        // +(BOOL)isVerbose;
        [Static]
        [Export ("isVerbose")]
        bool IsVerbose { get; }

        // -(void)setKeepCallbackAsBool:(BOOL)bKeepCallback;
        [Export ("setKeepCallbackAsBool:")]
        void SetKeepCallbackAsBool (bool bKeepCallback);

        // -(NSString *)argumentsAsJSON;
        [Export ("argumentsAsJSON")]
        string ArgumentsAsJson { get; }
    }

    // @interface QueueAdditions (NSMutableArray)
    [Category]
    [BaseType (typeof (NSMutableArray))]
    interface NSMutableArrayQueueAdditions
    {
        // -(id)cdv_pop;
        [Export ("cdv_pop")]
        NSObject CdvPop ();

        // -(id)cdv_queueHead;
        [Export ("cdv_queueHead")]
        NSObject CdvQueueHead ();

        // -(id)cdv_dequeue;
        [Export ("cdv_dequeue")]
        NSObject CdvDequeue ();

        // -(void)cdv_enqueue:(id)obj;
        [Export ("cdv_enqueue:")]
        void CdvEnqueue (NSObject obj);
    }

    // @interface org_apache_cordova_UIView_Extension (UIView)
    [Category]
    [BaseType (typeof (UIView))]
    interface UIView_org_apache_cordova_UIView_Extension
    {
        // @property (nonatomic, weak) UIScrollView * _Nullable scrollView;
        [NullAllowed, Export ("scrollView", ArgumentSemantic.Weak)]
        [Static]
        UIScrollView ScrollView { get; set; }
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const CDVPageDidLoadNotification;
        [Field ("CDVPageDidLoadNotification", "__Internal")]
        NSString CDVPageDidLoadNotification { get; }

        // extern NSString *const CDVPluginHandleOpenURLNotification;
        [Field ("CDVPluginHandleOpenURLNotification", "__Internal")]
        NSString CDVPluginHandleOpenURLNotification { get; }

        // extern NSString *const CDVPluginResetNotification;
        [Field ("CDVPluginResetNotification", "__Internal")]
        NSString CDVPluginResetNotification { get; }

        // extern NSString *const CDVLocalNotification;
        [Field ("CDVLocalNotification", "__Internal")]
        NSString CDVLocalNotification { get; }

        // extern NSString *const CDVRemoteNotification;
        [Field ("CDVRemoteNotification", "__Internal")]
        NSString CDVRemoteNotification { get; }

        // extern NSString *const CDVRemoteNotificationError;
        [Field ("CDVRemoteNotificationError", "__Internal")]
        NSString CDVRemoteNotificationError { get; }
    }

    // @interface CDVPlugin : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVPlugin
    {
        // -(instancetype)initWithWebViewEngine:(id<CDVWebViewEngineProtocol>)theWebViewEngine;
        [Export ("initWithWebViewEngine:")]
        IntPtr Constructor (CDVWebViewEngineProtocol theWebViewEngine);
 
        // @property (readonly, nonatomic, weak) UIView * _Nullable webView;
        [NullAllowed, Export ("webView", ArgumentSemantic.Weak)]
        UIView WebView { get; }

        // @property (readonly, nonatomic, weak) id<CDVWebViewEngineProtocol> _Nullable webViewEngine;
        [NullAllowed, Export ("webViewEngine", ArgumentSemantic.Weak)]
        CDVWebViewEngineProtocol WebViewEngine { get; }

        // @property (nonatomic, weak) UIViewController * _Nullable viewController;
        [NullAllowed, Export ("viewController", ArgumentSemantic.Weak)]
        UIViewController ViewController { get; set; }

        [Wrap ("WeakCommandDelegate")]
        [NullAllowed]
        CDVCommandDelegate CommandDelegate { get; set; }

        // @property (nonatomic, weak) id<CDVCommandDelegate> _Nullable commandDelegate;
        [NullAllowed, Export ("commandDelegate", ArgumentSemantic.Weak)]
        NSObject WeakCommandDelegate { get; set; }

        // @property (readonly, assign) BOOL hasPendingOperation;
        [Export ("hasPendingOperation")]
        bool HasPendingOperation { get; }

        // -(void)pluginInitialize;
        [Export ("pluginInitialize")]
        void PluginInitialize ();

        // -(void)handleOpenURL:(NSNotification *)notification;
        [Export ("handleOpenURL:")]
        void HandleOpenURL (NSNotification notification);

        // -(void)onAppTerminate;
        [Export ("onAppTerminate")]
        void OnAppTerminate ();

        // -(void)onMemoryWarning;
        [Export ("onMemoryWarning")]
        void OnMemoryWarning ();

        // -(void)onReset;
        [Export ("onReset")]
        void OnReset ();

        // -(void)dispose;
        [Export ("dispose")]
        void Dispose ();

        // -(id)appDelegate;
        [Export ("appDelegate")]
        NSObject AppDelegate { get; }
    }

    // @interface CDVViewController : UIViewController <CDVScreenOrientationDelegate>
    [BaseType (typeof (UIViewController))]
    interface CDVViewController : CDVScreenOrientationDelegate
    {
        // @property (readonly, nonatomic, weak) UIView * _Nullable webView __attribute__((iboutlet));
        [NullAllowed, Export ("webView", ArgumentSemantic.Weak)]
        UIView WebView { get; set; }

        // @property (readonly, nonatomic, strong) NSMutableDictionary * pluginObjects;
        [Export ("pluginObjects", ArgumentSemantic.Strong)]
        NSMutableDictionary PluginObjects { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary * pluginsMap;
        [Export ("pluginsMap", ArgumentSemantic.Strong)]
        NSDictionary PluginsMap { get; set; }

        // @property (readonly, nonatomic, strong) NSMutableDictionary * settings;
        [Export ("settings", ArgumentSemantic.Strong)]
        NSMutableDictionary Settings { get; }

        // @property (readonly, nonatomic, strong) NSXMLParser * configParser;
        //[Export ("configParser", ArgumentSemantic.Strong)]
        //NSXMLParser ConfigParser { get; }

        // @property (readwrite, copy, nonatomic) NSString * configFile;
        [Export ("configFile")]
        string ConfigFile { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * wwwFolderName;
        [Export ("wwwFolderName")]
        string WwwFolderName { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * startPage;
        [Export ("startPage")]
        string StartPage { get; set; }

        // @property (readonly, nonatomic, strong) CDVCommandQueue * commandQueue;
        [Export ("commandQueue", ArgumentSemantic.Strong)]
        CDVCommandQueue CommandQueue { get; }

        // @property (readonly, nonatomic, strong) id<CDVWebViewEngineProtocol> webViewEngine;
        [Export ("webViewEngine", ArgumentSemantic.Strong)]
        CDVWebViewEngineProtocol WebViewEngine { get; }

        [Wrap ("WeakCommandDelegate")]
        CDVCommandDelegate CommandDelegate { get; set; }

        // @property (readonly, nonatomic, strong) id<CDVCommandDelegate> commandDelegate;
        [/*NullAllowed,*/ Export ("commandDelegate", ArgumentSemantic.Strong)]
        NSObject WeakCommandDelegate { get; set;}
      
        // @property (readonly, nonatomic) NSString * userAgent;
        [Export ("userAgent")]
        string UserAgent { get; }

        // @property (readwrite, copy, nonatomic) NSString * baseUserAgent;
        [Export ("baseUserAgent")]
        string BaseUserAgent { get; set; }

        // @property (readonly, nonatomic) NSInteger * userAgentLockToken;
        [Export ("userAgentLockToken")]
        nint UserAgentLockToken { get; }

        // -(UIView *)newCordovaViewWithFrame:(CGRect)bounds;
        [Export ("newCordovaViewWithFrame:")]
        UIView NewCordovaViewWithFrame (CGRect bounds);

        // -(NSString *)appURLScheme;
        [Export ("appURLScheme")]
        string AppURLScheme { get; }

        // -(NSURL *)errorURL;
        [Export ("errorURL")]
        NSUrl ErrorURL { get; }

        // -(NSArray *)parseInterfaceOrientations:(NSArray *)orientations;
        [Export ("parseInterfaceOrientations:")]
        //[Verify (StronglyTypedNSArray)]
        NSObject [] ParseInterfaceOrientations (NSObject [] orientations);

        // -(BOOL)supportsOrientation:(UIInterfaceOrientation)orientation;
        [Export ("supportsOrientation:")]
        bool SupportsOrientation (UIInterfaceOrientation orientation);

        // -(id)getCommandInstance:(NSString *)pluginName;
        [Export ("getCommandInstance:")]
        NSObject GetCommandInstance (string pluginName);

        // -(void)registerPlugin:(CDVPlugin *)plugin withClassName:(NSString *)className;
        [Export ("registerPlugin:withClassName:")]
        void RegisterPluginClassName (CDVPlugin plugin, string className);

        // -(void)registerPlugin:(CDVPlugin *)plugin withPluginName:(NSString *)pluginName;
        [Export ("registerPlugin:withPluginName:")]
        void RegisterPluginPluginName (CDVPlugin plugin, string pluginName);

        // -(void)parseSettingsWithParser:(NSObject<NSXMLParserDelegate> *)delegate;
        //[Export ("parseSettingsWithParser:")]
        //void ParseSettingsWithParser (NSXMLParserDelegate @delegate);
    }

    // @interface CDVAppDelegate : NSObject <UIApplicationDelegate>
    [BaseType (typeof (NSObject))]
    interface CDVAppDelegate : IUIApplicationDelegate
    {
        // @property (nonatomic, strong) UIWindow * window __attribute__((iboutlet));
        [Export ("window", ArgumentSemantic.Strong)]
        UIWindow Window { get; set; }

        // @property (nonatomic, strong) CDVViewController * viewController __attribute__((iboutlet));
        [Export ("viewController", ArgumentSemantic.Strong)]
        CDVViewController ViewController { get; set; }
    }

    // @interface CDVURLProtocol : NSURLProtocol
    [BaseType (typeof (NSUrlProtocol))]
    interface CDVURLProtocol
    {
    }

    partial interface Constants
    {
        // extern NSString *const kCDVDefaultWhitelistRejectionString;
        [Field ("kCDVDefaultWhitelistRejectionString", "__Internal")]
        NSString kCDVDefaultWhitelistRejectionString { get; }
    }

    // @interface CDVWhitelist : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVWhitelist
    {
        // @property (copy, nonatomic) NSString * whitelistRejectionFormatString;
        [Export ("whitelistRejectionFormatString")]
        string WhitelistRejectionFormatString { get; set; }

        // -(id)initWithArray:(NSArray *)array;
        [Export ("initWithArray:")]
        //[Verify (StronglyTypedNSArray)]
        IntPtr Constructor (NSObject [] array);

        // -(BOOL)schemeIsAllowed:(NSString *)scheme;
        [Export ("schemeIsAllowed:")]
        bool SchemeIsAllowed (string scheme);

        // -(BOOL)URLIsAllowed:(NSURL *)url;
        [Export ("URLIsAllowed:")]
        bool URLIsAllowed (NSUrl url);

        // -(BOOL)URLIsAllowed:(NSURL *)url logFailure:(BOOL)logFailure;
        [Export ("URLIsAllowed:logFailure:")]
        bool URLIsAllowed (NSUrl url, bool logFailure);

        // -(NSString *)errorStringForURL:(NSURL *)url;
        [Export ("errorStringForURL:")]
        string ErrorStringForURL (NSUrl url);
    }

    // @interface CDVTimer : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVTimer
    {
        // +(void)start:(NSString *)name;
        [Static]
        [Export ("start:")]
        void Start (string name);

        // +(void)stop:(NSString *)name;
        [Static]
        [Export ("stop:")]
        void Stop (string name);
    }

    // @interface CDVUserAgentUtil : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVUserAgentUtil
    {
        // +(NSString *)originalUserAgent;
        [Static]
        [Export ("originalUserAgent")]
        string OriginalUserAgent { get; }

        // +(void)acquireLock:(void (^)(NSInteger))block;
        [Static]
        [Export ("acquireLock:")]
        void AcquireLock (Action<nint> block);

        // +(void)releaseLock:(NSInteger *)lockToken;
        [Static]
        [Export ("releaseLock:")]
        void ReleaseLock (nint lockToken);

        // +(void)setUserAgent:(NSString *)value lockToken:(NSInteger)lockToken;
        [Static]
        [Export ("setUserAgent:lockToken:")]
        void SetUserAgent (string value, nint lockToken);
    }

    // @interface CDVGestureHandler : CDVPlugin
    [BaseType (typeof (CDVPlugin))]
    interface CDVGestureHandler
    {
        // @property (nonatomic, strong) UILongPressGestureRecognizer * lpgr;
        [Export ("lpgr", ArgumentSemantic.Strong)]
        UILongPressGestureRecognizer Lpgr { get; set; }
    }

    // @interface CDVCommandDelegateImpl : NSObject <CDVCommandDelegate>
    [BaseType (typeof (NSObject))]
    interface CDVCommandDelegateImpl : CDVCommandDelegate
    {
        // -(id)initWithViewController:(CDVViewController *)viewController;
        [Export ("initWithViewController:")]
        IntPtr Constructor (CDVViewController viewController);

        // -(void)flushCommandQueueWithDelayedJs;
        [Export ("flushCommandQueueWithDelayedJs")]
        void FlushCommandQueueWithDelayedJs ();
    }

    // @interface CDVPluginResources (CDVPlugin)
    [Category]
    [BaseType (typeof (CDVPlugin))]
    interface CDVPlugin_CDVPluginResources
    {
        // -(NSString *)pluginLocalizedString:(NSString *)key;
        [Export ("pluginLocalizedString:")]
        string PluginLocalizedString (string key);

        // -(UIImage *)pluginImageResource:(NSString *)name;
        [Export ("pluginImageResource:")]
        UIImage PluginImageResource (string name);
    }

    // @interface CDVUIWebViewDelegate : NSObject <UIWebViewDelegate>
    [BaseType (typeof (NSObject))]
    interface CDVUIWebViewDelegate : IUIWebViewDelegate
    {
        // -(id)initWithDelegate:(NSObject<UIWebViewDelegate> *)delegate;
        [Export ("initWithDelegate:")]
        IntPtr Constructor (UIWebViewDelegate @delegate);

        // -(BOOL)request:(NSURLRequest *)newRequest isEqualToRequestAfterStrippingFragments:(NSURLRequest *)originalRequest;
        [Export ("request:isEqualToRequestAfterStrippingFragments:")]
        bool Request (NSUrlRequest newRequest, NSUrlRequest originalRequest);
    }

    // @interface CordovaPreferences (NSDictionary)
    [Category]
    [BaseType (typeof (NSDictionary))]
    interface NSDictionary_CordovaPreferences
    {
        // -(id)cordovaSettingForKey:(NSString *)key;
        [Export ("cordovaSettingForKey:")]
        NSObject CordovaSettingForKey (string key);

        // -(BOOL)cordovaBoolSettingForKey:(NSString *)key defaultValue:(BOOL)defaultValue;
        [Export ("cordovaBoolSettingForKey:defaultValue:")]
        bool CordovaBoolSettingForKey (string key, bool defaultValue);

        // -(CGFloat)cordovaFloatSettingForKey:(NSString *)key defaultValue:(CGFloat)defaultValue;
        [Export ("cordovaFloatSettingForKey:defaultValue:")]
        nfloat CordovaFloatSettingForKey (string key, nfloat defaultValue);
    }

    // @interface CordovaPreferences (NSMutableDictionary)
    [Category]
    [BaseType (typeof (NSMutableDictionary))]
    interface NSMutableDictionary_CordovaPreferences
    {
        // -(void)setCordovaSetting:(id)value forKey:(NSString *)key;
        [Export ("setCordovaSetting:forKey:")]
        void SetCordovaSetting (NSObject value, string key);
    }

    // @interface CDVConfigParser : NSObject <NSXMLParserDelegate>
    [BaseType (typeof (NSObject))]
    interface CDVConfigParser
    {
        // @property (readonly, nonatomic, strong) NSMutableDictionary * pluginsDict;
        [Export ("pluginsDict", ArgumentSemantic.Strong)]
        NSMutableDictionary PluginsDict { get; }

        // @property (readonly, nonatomic, strong) NSMutableDictionary * settings;
        [Export ("settings", ArgumentSemantic.Strong)]
        NSMutableDictionary Settings { get; }

        // @property (readonly, nonatomic, strong) NSMutableArray * startupPluginNames;
        [Export ("startupPluginNames", ArgumentSemantic.Strong)]
        NSMutableArray StartupPluginNames { get; }

        // @property (readonly, nonatomic, strong) NSString * startPage;
        [Export ("startPage", ArgumentSemantic.Strong)]
        string StartPage { get; }
    }

    // @interface CDVJSONSerializingPrivate (NSArray)
    [Category]
    [BaseType (typeof (NSArray))]
    interface NSArray_CDVJSONSerializingPrivate
    {
        // -(NSString *)cdv_JSONString;
        [Export ("cdv_JSONString")]
        [Static]
        string CdvJsonString { get; }
    }

    // @interface CDVJSONSerializingPrivate (NSDictionary)
    [Category]
    [BaseType (typeof (NSDictionary))]
    interface NSDictionary_CDVJSONSerializingPrivate
    {
        // -(NSString *)cdv_JSONString;
        [Static]
        [Export ("cdv_JSONString")]
        string CdvJsonString { get; }
    }

    // @interface CDVJSONSerializingPrivate (NSString)
    [Category]
    [BaseType (typeof (NSString))]
    interface NSString_CDVJSONSerializingPrivate
    {
        // -(id)cdv_JSONObject;
        [Export ("cdv_JSONObject")]
        [Static]
        NSObject CdvJsonObject { get; }

        // -(id)cdv_JSONFragment;
        [Export ("cdv_JSONFragment")]
        [Static]
        NSObject CdvJsonFragment { get; }
    }

    // @interface Private (CDVPlugin)
    /*[Category]
    [BaseType (typeof (CDVPlugin))]
    interface CDVPlugin_Private
    {
        // -(instancetype)initWithWebViewEngine:(id<CDVWebViewEngineProtocol>)theWebViewEngine;
        [Export ("initWithWebViewEngine:")]
        IntPtr Constructor (CDVWebViewEngineProtocol theWebViewEngine);
    }*/

    // @interface CDVLocalStorage : CDVPlugin
    [BaseType (typeof (CDVPlugin))]
    interface CDVLocalStorage
    {
        // @property (readonly, nonatomic, strong) NSMutableArray * backupInfo;
        [Export ("backupInfo", ArgumentSemantic.Strong)]
        NSMutableArray BackupInfo { get; }

        // -(BOOL)shouldBackup;
        [Export ("shouldBackup")]
        bool ShouldBackup { get; }

        // -(BOOL)shouldRestore;
        [Export ("shouldRestore")]
        bool ShouldRestore { get; }

        // -(void)backup:(CDVInvokedUrlCommand *)command;
        [Export ("backup:")]
        void Backup (CDVInvokedUrlCommand command);

        // -(void)restore:(CDVInvokedUrlCommand *)command;
        [Export ("restore:")]
        void Restore (CDVInvokedUrlCommand command);

        // +(void)__fixupDatabaseLocationsWithBackupType:(NSString *)backupType;
        [Static]
        [Export ("__fixupDatabaseLocationsWithBackupType:")]
        void FixupDatabaseLocationsWithBackupType (string backupType);

        // +(BOOL)__verifyAndFixDatabaseLocationsWithAppPlistDict:(NSMutableDictionary *)appPlistDict bundlePath:(NSString *)bundlePath fileManager:(NSFileManager *)fileManager;
        [Static]
        [Export ("__verifyAndFixDatabaseLocationsWithAppPlistDict:bundlePath:fileManager:")]
        bool VerifyAndFixDatabaseLocationsWithAppPlistDict (NSMutableDictionary appPlistDict, string bundlePath, NSFileManager fileManager);
    }

    // @interface CDVBackupInfo : NSObject
    [BaseType (typeof (NSObject))]
    interface CDVBackupInfo
    {
        // @property (copy, nonatomic) NSString * original;
        [Export ("original")]
        string Original { get; set; }

        // @property (copy, nonatomic) NSString * backup;
        [Export ("backup")]
        string Backup { get; set; }

        // @property (copy, nonatomic) NSString * label;
        [Export ("label")]
        string Label { get; set; }

        // -(BOOL)shouldBackup;
        [Export ("shouldBackup")]
        bool ShouldBackup { get; }

        // -(BOOL)shouldRestore;
        [Export ("shouldRestore")]
        bool ShouldRestore { get; }
    }

    // @interface CDVIntentAndNavigationFilter : CDVPlugin <NSXMLParserDelegate>
    [BaseType (typeof (CDVPlugin))]
    interface CDVIntentAndNavigationFilter
    {
    }

    // @interface CDVUIWebViewEngine : CDVPlugin <CDVWebViewEngineProtocol>
    [BaseType (typeof (CDVPlugin))]
    interface CDVUIWebViewEngine : CDVWebViewEngineProtocol
    {
        [Wrap ("WeakUiWebViewDelegate")]
        UIWebViewDelegate UiWebViewDelegate { get; }

        // @property (readonly, nonatomic, strong) id<UIWebViewDelegate> uiWebViewDelegate;
        [NullAllowed, Export ("uiWebViewDelegate", ArgumentSemantic.Strong)]
        NSObject WeakUiWebViewDelegate { get; }
    }

    // @interface CDVHandleOpenURL : CDVPlugin
    [BaseType (typeof (CDVPlugin))]
    interface CDVHandleOpenURL
    {
        // @property (nonatomic, strong) NSURL * url;
        [Export ("url", ArgumentSemantic.Strong)]
        NSUrl Url { get; set; }

        // @property (assign, nonatomic) BOOL pageLoaded;
        [Export ("pageLoaded")]
        bool PageLoaded { get; set; }
    }

    // @interface CDVUIWebViewNavigationDelegate : NSObject <UIWebViewDelegate>
    [BaseType (typeof (NSObject))]
    interface CDVUIWebViewNavigationDelegate : IUIWebViewDelegate
    {
        // @property (nonatomic, weak) CDVPlugin * _Nullable enginePlugin;
        [NullAllowed, Export ("enginePlugin", ArgumentSemantic.Weak)]
        CDVPlugin EnginePlugin { get; set; }

        // -(instancetype)initWithEnginePlugin:(CDVPlugin *)enginePlugin;
        [Export ("initWithEnginePlugin:")]
        IntPtr Constructor (CDVPlugin enginePlugin);
    }
}