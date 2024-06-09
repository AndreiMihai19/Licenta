; ModuleID = 'obj\Release\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [152 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 60
	i32 57263871, ; 1: Xamarin.Forms.Core.dll => 0x369c6ff => 55
	i32 83768722, ; 2: Microsoft.AspNetCore.Cryptography.Internal => 0x4fe3592 => 11
	i32 134690465, ; 3: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 64
	i32 182336117, ; 4: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 52
	i32 224529992, ; 5: MobileApp.Android => 0xd620e48 => 0
	i32 318968648, ; 6: Xamarin.AndroidX.Activity.dll => 0x13031348 => 35
	i32 321597661, ; 7: System.Numerics => 0x132b30dd => 26
	i32 342366114, ; 8: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 46
	i32 442521989, ; 9: Xamarin.Essentials => 0x1a605985 => 54
	i32 450948140, ; 10: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 44
	i32 465846621, ; 11: mscorlib => 0x1bc4415d => 17
	i32 469710990, ; 12: System.dll => 0x1bff388e => 24
	i32 526420162, ; 13: System.Transactions.dll => 0x1f6088c2 => 70
	i32 527452488, ; 14: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 64
	i32 548916678, ; 15: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 13
	i32 618636221, ; 16: K4os.Compression.LZ4.Streams => 0x24dfa3bd => 9
	i32 627609679, ; 17: Xamarin.AndroidX.CustomView => 0x2568904f => 42
	i32 662205335, ; 18: System.Text.Encodings.Web.dll => 0x27787397 => 32
	i32 691348768, ; 19: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 66
	i32 700284507, ; 20: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 61
	i32 720511267, ; 21: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 65
	i32 722857257, ; 22: System.Runtime.Loader.dll => 0x2b15ed29 => 28
	i32 770880312, ; 23: MobileApp.dll => 0x2df2b338 => 15
	i32 809851609, ; 24: System.Drawing.Common.dll => 0x30455ad9 => 71
	i32 837694855, ; 25: MobileApp => 0x31ee3587 => 15
	i32 928116545, ; 26: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 60
	i32 956575887, ; 27: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 65
	i32 967690846, ; 28: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 46
	i32 974778368, ; 29: FormsViewGroup.dll => 0x3a19f000 => 5
	i32 983077409, ; 30: MySql.Data.dll => 0x3a989221 => 18
	i32 1012816738, ; 31: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 51
	i32 1035644815, ; 32: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 37
	i32 1042160112, ; 33: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 57
	i32 1052210849, ; 34: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 48
	i32 1084122840, ; 35: Xamarin.Kotlin.StdLib => 0x409e66d8 => 63
	i32 1098259244, ; 36: System => 0x41761b2c => 24
	i32 1135815421, ; 37: Microsoft.AspNetCore.Cryptography.KeyDerivation.dll => 0x43b32afd => 12
	i32 1275534314, ; 38: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 66
	i32 1293217323, ; 39: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 43
	i32 1365406463, ; 40: System.ServiceModel.Internals.dll => 0x516272ff => 72
	i32 1376866003, ; 41: Xamarin.AndroidX.SavedState => 0x52114ed3 => 51
	i32 1406073936, ; 42: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 39
	i32 1411638395, ; 43: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 27
	i32 1460219004, ; 44: Xamarin.Forms.Xaml => 0x57092c7c => 58
	i32 1469204771, ; 45: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 36
	i32 1487250139, ; 46: K4os.Hash.xxHash => 0x58a5a2db => 10
	i32 1511525525, ; 47: MySqlConnector => 0x5a180c95 => 19
	i32 1592978981, ; 48: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 49: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 49
	i32 1636350590, ; 50: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 41
	i32 1639515021, ; 51: System.Net.Http.dll => 0x61b9038d => 2
	i32 1658251792, ; 52: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 59
	i32 1698840827, ; 53: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 62
	i32 1729485958, ; 54: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 38
	i32 1746115085, ; 55: System.IO.Pipelines.dll => 0x68139a0d => 25
	i32 1766324549, ; 56: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 52
	i32 1776026572, ; 57: System.Core.dll => 0x69dc03cc => 22
	i32 1788241197, ; 58: Xamarin.AndroidX.Fragment => 0x6a96652d => 44
	i32 1796167890, ; 59: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 13
	i32 1808609942, ; 60: Xamarin.AndroidX.Loader => 0x6bcd3296 => 49
	i32 1813058853, ; 61: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 63
	i32 1813201214, ; 62: Xamarin.Google.Android.Material => 0x6c13413e => 59
	i32 1820883333, ; 63: Microsoft.AspNetCore.Cryptography.Internal.dll => 0x6c887985 => 11
	i32 1828688058, ; 64: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 14
	i32 1867746548, ; 65: Xamarin.Essentials.dll => 0x6f538cf4 => 54
	i32 1878053835, ; 66: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 58
	i32 1880436471, ; 67: MobileApp.Android.dll => 0x70152ef7 => 0
	i32 1925302748, ; 68: K4os.Compression.LZ4.dll => 0x72c1c9dc => 8
	i32 1983156543, ; 69: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 62
	i32 2011961780, ; 70: System.Buffers.dll => 0x77ec19b4 => 20
	i32 2019465201, ; 71: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 48
	i32 2055257422, ; 72: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 47
	i32 2097448633, ; 73: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 45
	i32 2126786730, ; 74: Xamarin.Forms.Platform.Android => 0x7ec430aa => 56
	i32 2192057212, ; 75: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 14
	i32 2201107256, ; 76: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 67
	i32 2201231467, ; 77: System.Net.Http => 0x8334206b => 2
	i32 2265110946, ; 78: System.Security.AccessControl.dll => 0x8702d9a2 => 29
	i32 2279755925, ; 79: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 50
	i32 2383496789, ; 80: System.Security.Principal.Windows.dll => 0x8e114655 => 31
	i32 2475788418, ; 81: Java.Interop.dll => 0x93918882 => 7
	i32 2486824558, ; 82: K4os.Hash.xxHash.dll => 0x9439ee6e => 10
	i32 2498657740, ; 83: BouncyCastle.Cryptography.dll => 0x94ee7dcc => 4
	i32 2570120770, ; 84: System.Text.Encodings.Web => 0x9930ee42 => 32
	i32 2605712449, ; 85: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 67
	i32 2611359322, ; 86: ZstdSharp.dll => 0x9ba62e5a => 68
	i32 2620871830, ; 87: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 41
	i32 2663698177, ; 88: System.Runtime.Loader => 0x9ec4cf01 => 28
	i32 2732626843, ; 89: Xamarin.AndroidX.Activity => 0xa2e0939b => 35
	i32 2737747696, ; 90: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 36
	i32 2765824710, ; 91: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 1
	i32 2766581644, ; 92: Xamarin.Forms.Core => 0xa4e6af8c => 55
	i32 2770495804, ; 93: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 61
	i32 2778768386, ; 94: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 53
	i32 2810250172, ; 95: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 39
	i32 2819470561, ; 96: System.Xml.dll => 0xa80db4e1 => 34
	i32 2841355853, ; 97: System.Security.Permissions => 0xa95ba64d => 30
	i32 2853208004, ; 98: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 53
	i32 2905242038, ; 99: mscorlib.dll => 0xad2a79b6 => 17
	i32 2944313911, ; 100: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 21
	i32 2968338931, ; 101: System.Security.Principal.Windows => 0xb0ed41f3 => 31
	i32 2978675010, ; 102: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 43
	i32 3012788804, ; 103: System.Configuration.ConfigurationManager => 0xb3938244 => 21
	i32 3014607031, ; 104: Microsoft.AspNetCore.Cryptography.KeyDerivation => 0xb3af40b7 => 12
	i32 3025069135, ; 105: K4os.Compression.LZ4.Streams.dll => 0xb44ee44f => 9
	i32 3044182254, ; 106: FormsViewGroup => 0xb57288ee => 5
	i32 3089219899, ; 107: ZstdSharp => 0xb821c13b => 68
	i32 3111772706, ; 108: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3124832203, ; 109: System.Threading.Tasks.Extensions => 0xba4127cb => 75
	i32 3132293585, ; 110: System.Security.AccessControl => 0xbab301d1 => 29
	i32 3204380047, ; 111: System.Data.dll => 0xbefef58f => 69
	i32 3213246214, ; 112: System.Security.Permissions.dll => 0xbf863f06 => 30
	i32 3247949154, ; 113: Mono.Security => 0xc197c562 => 74
	i32 3258312781, ; 114: Xamarin.AndroidX.CardView => 0xc235e84d => 38
	i32 3265893370, ; 115: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 75
	i32 3317135071, ; 116: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 42
	i32 3317144872, ; 117: System.Data => 0xc5b79d28 => 69
	i32 3353484488, ; 118: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 45
	i32 3358260929, ; 119: System.Text.Json => 0xc82afec1 => 33
	i32 3362522851, ; 120: Xamarin.AndroidX.Core => 0xc86c06e3 => 40
	i32 3366347497, ; 121: Java.Interop => 0xc8a662e9 => 7
	i32 3374999561, ; 122: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 50
	i32 3381033598, ; 123: K4os.Compression.LZ4 => 0xc9867a7e => 8
	i32 3395150330, ; 124: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 27
	i32 3404865022, ; 125: System.ServiceModel.Internals => 0xcaf21dfe => 72
	i32 3429136800, ; 126: System.Xml => 0xcc6479a0 => 34
	i32 3467345667, ; 127: MySql.Data => 0xceab7f03 => 18
	i32 3476120550, ; 128: Mono.Android => 0xcf3163e6 => 16
	i32 3485117614, ; 129: System.Text.Json.dll => 0xcfbaacae => 33
	i32 3486566296, ; 130: System.Transactions => 0xcfd0c798 => 70
	i32 3499097210, ; 131: Google.Protobuf.dll => 0xd08ffc7a => 6
	i32 3515174580, ; 132: System.Security.dll => 0xd1854eb4 => 73
	i32 3536029504, ; 133: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 56
	i32 3605570793, ; 134: BouncyCastle.Cryptography => 0xd6e8a4e9 => 4
	i32 3632359727, ; 135: Xamarin.Forms.Platform => 0xd881692f => 57
	i32 3641597786, ; 136: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 47
	i32 3645630983, ; 137: Google.Protobuf => 0xd94bea07 => 6
	i32 3672681054, ; 138: Mono.Android.dll => 0xdae8aa5e => 16
	i32 3689375977, ; 139: System.Drawing.Common => 0xdbe768e9 => 71
	i32 3748608112, ; 140: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 23
	i32 3829621856, ; 141: System.Numerics.dll => 0xe4436460 => 26
	i32 3896760992, ; 142: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 40
	i32 3953953790, ; 143: System.Text.Encoding.CodePages => 0xebac8bfe => 1
	i32 3955647286, ; 144: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 37
	i32 4023392905, ; 145: System.IO.Pipelines => 0xefd01a89 => 25
	i32 4079385022, ; 146: MySqlConnector.dll => 0xf32679be => 19
	i32 4105002889, ; 147: Mono.Security.dll => 0xf4ad5f89 => 74
	i32 4151237749, ; 148: System.Core => 0xf76edc75 => 22
	i32 4185676441, ; 149: System.Security => 0xf97c5a99 => 73
	i32 4213026141, ; 150: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 23
	i32 4260525087 ; 151: System.Buffers => 0xfdf2741f => 20
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [152 x i32] [
	i32 60, i32 55, i32 11, i32 64, i32 52, i32 0, i32 35, i32 26, ; 0..7
	i32 46, i32 54, i32 44, i32 17, i32 24, i32 70, i32 64, i32 13, ; 8..15
	i32 9, i32 42, i32 32, i32 66, i32 61, i32 65, i32 28, i32 15, ; 16..23
	i32 71, i32 15, i32 60, i32 65, i32 46, i32 5, i32 18, i32 51, ; 24..31
	i32 37, i32 57, i32 48, i32 63, i32 24, i32 12, i32 66, i32 43, ; 32..39
	i32 72, i32 51, i32 39, i32 27, i32 58, i32 36, i32 10, i32 19, ; 40..47
	i32 3, i32 49, i32 41, i32 2, i32 59, i32 62, i32 38, i32 25, ; 48..55
	i32 52, i32 22, i32 44, i32 13, i32 49, i32 63, i32 59, i32 11, ; 56..63
	i32 14, i32 54, i32 58, i32 0, i32 8, i32 62, i32 20, i32 48, ; 64..71
	i32 47, i32 45, i32 56, i32 14, i32 67, i32 2, i32 29, i32 50, ; 72..79
	i32 31, i32 7, i32 10, i32 4, i32 32, i32 67, i32 68, i32 41, ; 80..87
	i32 28, i32 35, i32 36, i32 1, i32 55, i32 61, i32 53, i32 39, ; 88..95
	i32 34, i32 30, i32 53, i32 17, i32 21, i32 31, i32 43, i32 21, ; 96..103
	i32 12, i32 9, i32 5, i32 68, i32 3, i32 75, i32 29, i32 69, ; 104..111
	i32 30, i32 74, i32 38, i32 75, i32 42, i32 69, i32 45, i32 33, ; 112..119
	i32 40, i32 7, i32 50, i32 8, i32 27, i32 72, i32 34, i32 18, ; 120..127
	i32 16, i32 33, i32 70, i32 6, i32 73, i32 56, i32 4, i32 57, ; 128..135
	i32 47, i32 6, i32 16, i32 71, i32 23, i32 26, i32 40, i32 1, ; 136..143
	i32 37, i32 25, i32 19, i32 74, i32 22, i32 73, i32 23, i32 20 ; 152..151
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
