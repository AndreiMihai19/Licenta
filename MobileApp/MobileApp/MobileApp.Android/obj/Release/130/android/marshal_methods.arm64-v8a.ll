; ModuleID = 'obj\Release\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Release\130\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [152 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 16
	i64 232391251801502327, ; 1: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 51
	i64 486223428996552534, ; 2: ZstdSharp.dll => 0x6bf69a1eecfd756 => 68
	i64 595053104451889001, ; 3: MySql.Data => 0x8420da551592769 => 18
	i64 702024105029695270, ; 4: System.Drawing.Common => 0x9be17343c0e7726 => 71
	i64 720058930071658100, ; 5: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 45
	i64 872800313462103108, ; 6: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 43
	i64 940822596282819491, ; 7: System.Transactions => 0xd0e792aa81923a3 => 70
	i64 996343623809489702, ; 8: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 57
	i64 1000557547492888992, ; 9: Mono.Security.dll => 0xde2b1c9cba651a0 => 74
	i64 1120440138749646132, ; 10: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 59
	i64 1425944114962822056, ; 11: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 3
	i64 1624659445732251991, ; 12: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 36
	i64 1639340239664632727, ; 13: Microsoft.AspNetCore.Cryptography.Internal.dll => 0x16c01b432b36d397 => 11
	i64 1769105627832031750, ; 14: Google.Protobuf => 0x188d203205129a06 => 6
	i64 1795316252682057001, ; 15: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 37
	i64 1836611346387731153, ; 16: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 51
	i64 1865037103900624886, ; 17: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 13
	i64 1981742497975770890, ; 18: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 48
	i64 2040001226662520565, ; 19: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 75
	i64 2064708342624596306, ; 20: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 64
	i64 2262844636196693701, ; 21: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 43
	i64 2329709569556905518, ; 22: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 47
	i64 2335503487726329082, ; 23: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 32
	i64 2337758774805907496, ; 24: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 27
	i64 2470498323731680442, ; 25: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 39
	i64 2547086958574651984, ; 26: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 35
	i64 2592350477072141967, ; 27: System.Xml.dll => 0x23f9e10627330e8f => 34
	i64 2624866290265602282, ; 28: mscorlib.dll => 0x246d65fbde2db8ea => 17
	i64 2783046991838674048, ; 29: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 27
	i64 2815524396660695947, ; 30: System.Security.AccessControl => 0x2712c0857f68238b => 29
	i64 2851879596360956261, ; 31: System.Configuration.ConfigurationManager => 0x2793e9620b477965 => 21
	i64 2960931600190307745, ; 32: Xamarin.Forms.Core => 0x2917579a49927da1 => 55
	i64 3017704767998173186, ; 33: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 59
	i64 3289520064315143713, ; 34: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 46
	i64 3344514922410554693, ; 35: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 67
	i64 3522470458906976663, ; 36: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 52
	i64 3531994851595924923, ; 37: System.Numerics => 0x31042a9aade235bb => 26
	i64 3727469159507183293, ; 38: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 50
	i64 4525561845656915374, ; 39: System.ServiceModel.Internals => 0x3ece06856b710dae => 72
	i64 4794310189461587505, ; 40: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 35
	i64 4795410492532947900, ; 41: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 52
	i64 4853321196694829351, ; 42: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 28
	i64 5032256205035195147, ; 43: MySql.Data.dll => 0x45d62a5b3fe0cb0b => 18
	i64 5142919913060024034, ; 44: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 56
	i64 5203618020066742981, ; 45: Xamarin.Essentials => 0x4836f704f0e652c5 => 54
	i64 5290786973231294105, ; 46: System.Runtime.Loader => 0x496ca6b869b72699 => 28
	i64 5507995362134886206, ; 47: System.Core.dll => 0x4c705499688c873e => 22
	i64 5812387745074149618, ; 48: K4os.Compression.LZ4.dll => 0x50a9bfdbd9fa78f2 => 8
	i64 6085203216496545422, ; 49: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 57
	i64 6086316965293125504, ; 50: FormsViewGroup.dll => 0x5476f10882baef80 => 5
	i64 6222399776351216807, ; 51: System.Text.Json.dll => 0x565a67a0ffe264a7 => 33
	i64 6401687960814735282, ; 52: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 47
	i64 6548213210057960872, ; 53: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 42
	i64 6617685658146568858, ; 54: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 1
	i64 6659513131007730089, ; 55: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 45
	i64 7378352852197400208, ; 56: MobileApp.dll => 0x66652cd3aeb75e90 => 15
	i64 7451202609009583483, ; 57: K4os.Hash.xxHash => 0x6767fd4b737ae57b => 10
	i64 7635363394907363464, ; 58: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 55
	i64 7637365915383206639, ; 59: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 54
	i64 7654504624184590948, ; 60: System.Net.Http => 0x6a3a4366801b8264 => 2
	i64 7702918024138448955, ; 61: MySqlConnector => 0x6ae6432192b9e03b => 19
	i64 7735352534559001595, ; 62: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 63
	i64 7820441508502274321, ; 63: System.Data => 0x6c87ca1e14ff8111 => 69
	i64 7836164640616011524, ; 64: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 36
	i64 8083354569033831015, ; 65: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 46
	i64 8087206902342787202, ; 66: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 23
	i64 8167236081217502503, ; 67: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 7
	i64 8187640529827139739, ; 68: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 66
	i64 8442828414178614895, ; 69: Microsoft.AspNetCore.Cryptography.KeyDerivation => 0x752af3b5eeb0de6f => 12
	i64 8476857680833348370, ; 70: System.Security.Permissions.dll => 0x75a3d925fd9d0312 => 30
	i64 8626175481042262068, ; 71: Java.Interop => 0x77b654e585b55834 => 7
	i64 8725526185868997716, ; 72: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 23
	i64 8853378295825400934, ; 73: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 62
	i64 9020594094058907638, ; 74: MobileApp.Android => 0x7d2f96890f5e27f6 => 0
	i64 9286073997824813334, ; 75: BouncyCastle.Cryptography => 0x80dec319ee56e916 => 4
	i64 9324707631942237306, ; 76: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 37
	i64 9508211702228543126, ; 77: Microsoft.AspNetCore.Cryptography.KeyDerivation.dll => 0x83f3f42aa08b6696 => 12
	i64 9662334977499516867, ; 78: System.Numerics.dll => 0x8617827802b0cfc3 => 26
	i64 9678050649315576968, ; 79: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 39
	i64 9808709177481450983, ; 80: Mono.Android.dll => 0x881f890734e555e7 => 16
	i64 9834056768316610435, ; 81: System.Transactions.dll => 0x8879968718899783 => 70
	i64 9864374015518639636, ; 82: Microsoft.AspNetCore.Cryptography.Internal => 0x88e54be746950614 => 11
	i64 9998632235833408227, ; 83: Mono.Security => 0x8ac2470b209ebae3 => 74
	i64 9998685624638532270, ; 84: K4os.Hash.xxHash.dll => 0x8ac27799ad626aae => 10
	i64 10038780035334861115, ; 85: System.Net.Http.dll => 0x8b50e941206af13b => 2
	i64 10226222362177979215, ; 86: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 64
	i64 10229024438826829339, ; 87: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 42
	i64 10321854143672141184, ; 88: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 61
	i64 10406448008575299332, ; 89: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 67
	i64 10430153318873392755, ; 90: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 40
	i64 10447083246144586668, ; 91: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 13
	i64 10885087467875303060, ; 92: K4os.Compression.LZ4.Streams => 0x970f99615fc37e94 => 9
	i64 11002576679268595294, ; 93: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 14
	i64 11023048688141570732, ; 94: System.Core => 0x98f9bc61168392ac => 22
	i64 11037814507248023548, ; 95: System.Xml => 0x992e31d0412bf7fc => 34
	i64 11162124722117608902, ; 96: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 53
	i64 11340910727871153756, ; 97: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 41
	i64 11341245327015630248, ; 98: System.Configuration.ConfigurationManager.dll => 0x9d643289535355a8 => 21
	i64 11513602507638267977, ; 99: System.IO.Pipelines.dll => 0x9fc8887aa0d36049 => 25
	i64 11529969570048099689, ; 100: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 53
	i64 12063623837170009990, ; 101: System.Security => 0xa76a99f6ce740786 => 73
	i64 12102847907131387746, ; 102: System.Buffers => 0xa7f5f40c43256f62 => 20
	i64 12145679461940342714, ; 103: System.Text.Json => 0xa88e1f1ebcb62fba => 33
	i64 12313367145828839434, ; 104: System.IO.Pipelines => 0xaae1de2e1c17f00a => 25
	i64 12451044538927396471, ; 105: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 44
	i64 12466513435562512481, ; 106: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 49
	i64 12538491095302438457, ; 107: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 38
	i64 12551451704392164662, ; 108: MySqlConnector.dll => 0xae2fb6d31fc42536 => 19
	i64 12828192437253469131, ; 109: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 65
	i64 12963446364377008305, ; 110: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 71
	i64 12983926868845145925, ; 111: MobileApp => 0xb4302cb2072a2f45 => 15
	i64 13162471042547327635, ; 112: System.Security.Permissions => 0xb6aa7dace9662293 => 30
	i64 13370592475155966277, ; 113: System.Runtime.Serialization => 0xb98de304062ea945 => 3
	i64 13454009404024712428, ; 114: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 60
	i64 13465488254036897740, ; 115: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 63
	i64 13572454107664307259, ; 116: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 50
	i64 13647894001087880694, ; 117: System.Data.dll => 0xbd670f48cb071df6 => 69
	i64 13710614125866346983, ; 118: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 29
	i64 13828521679616088467, ; 119: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 62
	i64 13959074834287824816, ; 120: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 44
	i64 13967638549803255703, ; 121: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 56
	i64 14124974489674258913, ; 122: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 38
	i64 14551742072151931844, ; 123: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 32
	i64 14792063746108907174, ; 124: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 60
	i64 14852515768018889994, ; 125: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 41
	i64 14912225920358050525, ; 126: System.Security.Principal.Windows => 0xcef2de7759506add => 31
	i64 14935719434541007538, ; 127: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 1
	i64 15279429628684179188, ; 128: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 66
	i64 15370334346939861994, ; 129: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 40
	i64 15609085926864131306, ; 130: System.dll => 0xd89e9cf3334914ea => 24
	i64 15620612276725577442, ; 131: BouncyCastle.Cryptography.dll => 0xd8c7901aa85576e2 => 4
	i64 15810740023422282496, ; 132: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 58
	i64 15963349826457351533, ; 133: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 75
	i64 16154507427712707110, ; 134: System => 0xe03056ea4e39aa26 => 24
	i64 16321164108206115771, ; 135: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 14
	i64 16337011941688632206, ; 136: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 31
	i64 16423015068819898779, ; 137: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 65
	i64 16637862623548895820, ; 138: K4os.Compression.LZ4 => 0xe6e58fe7aa61724c => 8
	i64 16833383113903931215, ; 139: mscorlib => 0xe99c30c1484d7f4f => 17
	i64 16873478996345296124, ; 140: K4os.Compression.LZ4.Streams.dll => 0xea2aa3bf662d14fc => 9
	i64 17553799493972570483, ; 141: Google.Protobuf.dll => 0xf39b9fa2c0aab173 => 6
	i64 17704177640604968747, ; 142: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 49
	i64 17710060891934109755, ; 143: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 48
	i64 17838668724098252521, ; 144: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 20
	i64 17882897186074144999, ; 145: FormsViewGroup => 0xf82cd03e3ac830e7 => 5
	i64 17891337867145587222, ; 146: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 61
	i64 17892495832318972303, ; 147: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 58
	i64 17979120673405951447, ; 148: ZstdSharp => 0xf982aafeb83e5dd7 => 68
	i64 18129453464017766560, ; 149: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 72
	i64 18198860413169718079, ; 150: MobileApp.Android.dll => 0xfc8f571fc3e6533f => 0
	i64 18318849532986632368 ; 151: System.Security.dll => 0xfe39a097c37fa8b0 => 73
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [152 x i32] [
	i32 16, i32 51, i32 68, i32 18, i32 71, i32 45, i32 43, i32 70, ; 0..7
	i32 57, i32 74, i32 59, i32 3, i32 36, i32 11, i32 6, i32 37, ; 8..15
	i32 51, i32 13, i32 48, i32 75, i32 64, i32 43, i32 47, i32 32, ; 16..23
	i32 27, i32 39, i32 35, i32 34, i32 17, i32 27, i32 29, i32 21, ; 24..31
	i32 55, i32 59, i32 46, i32 67, i32 52, i32 26, i32 50, i32 72, ; 32..39
	i32 35, i32 52, i32 28, i32 18, i32 56, i32 54, i32 28, i32 22, ; 40..47
	i32 8, i32 57, i32 5, i32 33, i32 47, i32 42, i32 1, i32 45, ; 48..55
	i32 15, i32 10, i32 55, i32 54, i32 2, i32 19, i32 63, i32 69, ; 56..63
	i32 36, i32 46, i32 23, i32 7, i32 66, i32 12, i32 30, i32 7, ; 64..71
	i32 23, i32 62, i32 0, i32 4, i32 37, i32 12, i32 26, i32 39, ; 72..79
	i32 16, i32 70, i32 11, i32 74, i32 10, i32 2, i32 64, i32 42, ; 80..87
	i32 61, i32 67, i32 40, i32 13, i32 9, i32 14, i32 22, i32 34, ; 88..95
	i32 53, i32 41, i32 21, i32 25, i32 53, i32 73, i32 20, i32 33, ; 96..103
	i32 25, i32 44, i32 49, i32 38, i32 19, i32 65, i32 71, i32 15, ; 104..111
	i32 30, i32 3, i32 60, i32 63, i32 50, i32 69, i32 29, i32 62, ; 112..119
	i32 44, i32 56, i32 38, i32 32, i32 60, i32 41, i32 31, i32 1, ; 120..127
	i32 66, i32 40, i32 24, i32 4, i32 58, i32 75, i32 24, i32 14, ; 128..135
	i32 31, i32 65, i32 8, i32 17, i32 9, i32 6, i32 49, i32 48, ; 136..143
	i32 20, i32 5, i32 61, i32 58, i32 68, i32 72, i32 0, i32 73 ; 152..151
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
