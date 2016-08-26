using System;
using ObjCRuntime;

[assembly: LinkWith ("libCordovaFat.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator, Frameworks = "AssetsLibrary CoreLocation CoreGraphics MobileCoreServices", ForceLoad = true, LinkerFlags = "-lz -ObjC -fobjc-arc")]