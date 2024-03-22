; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [258 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 73
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 105
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 100
	i32 83768722, ; 3: Microsoft.AspNetCore.Cryptography.Internal => 0x4fe3592 => 12
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 89
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 89
	i32 134690465, ; 6: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 109
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 50
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 91
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 48
	i32 224529992, ; 10: MobileApp.Android => 0xd620e48 => 0
	i32 230216969, ; 11: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 67
	i32 232815796, ; 12: System.Web.Services => 0xde07cb4 => 121
	i32 261689757, ; 13: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 53
	i32 278686392, ; 14: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 71
	i32 280482487, ; 15: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 65
	i32 318968648, ; 16: Xamarin.AndroidX.Activity.dll => 0x13031348 => 40
	i32 321597661, ; 17: System.Numerics => 0x132b30dd => 28
	i32 342366114, ; 18: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 69
	i32 385762202, ; 19: System.Memory.dll => 0x16fe439a => 27
	i32 441335492, ; 20: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 52
	i32 442521989, ; 21: Xamarin.Essentials => 0x1a605985 => 99
	i32 450948140, ; 22: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 64
	i32 465846621, ; 23: mscorlib => 0x1bc4415d => 18
	i32 469710990, ; 24: System.dll => 0x1bff388e => 25
	i32 476646585, ; 25: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 65
	i32 486930444, ; 26: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 77
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 115
	i32 527452488, ; 28: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 109
	i32 548916678, ; 29: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 14
	i32 605376203, ; 30: System.IO.Compression.FileSystem => 0x24154ecb => 119
	i32 618636221, ; 31: K4os.Compression.LZ4.Streams => 0x24dfa3bd => 10
	i32 627609679, ; 32: Xamarin.AndroidX.CustomView => 0x2568904f => 58
	i32 639843206, ; 33: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 63
	i32 662205335, ; 34: System.Text.Encodings.Web.dll => 0x27787397 => 36
	i32 663517072, ; 35: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 96
	i32 666292255, ; 36: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 45
	i32 690569205, ; 37: System.Xml.Linq.dll => 0x29293ff5 => 39
	i32 691348768, ; 38: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 111
	i32 700284507, ; 39: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 106
	i32 720511267, ; 40: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 110
	i32 722857257, ; 41: System.Runtime.Loader.dll => 0x2b15ed29 => 32
	i32 770880312, ; 42: MobileApp.dll => 0x2df2b338 => 16
	i32 775507847, ; 43: System.IO.Compression => 0x2e394f87 => 118
	i32 809851609, ; 44: System.Drawing.Common.dll => 0x30455ad9 => 117
	i32 837694855, ; 45: MobileApp => 0x31ee3587 => 16
	i32 843511501, ; 46: Xamarin.AndroidX.Print => 0x3246f6cd => 84
	i32 928116545, ; 47: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 105
	i32 956575887, ; 48: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 110
	i32 967690846, ; 49: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 69
	i32 974778368, ; 50: FormsViewGroup.dll => 0x3a19f000 => 6
	i32 983077409, ; 51: MySql.Data.dll => 0x3a989221 => 19
	i32 1012816738, ; 52: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 88
	i32 1035644815, ; 53: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 44
	i32 1042160112, ; 54: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 102
	i32 1052210849, ; 55: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 74
	i32 1084122840, ; 56: Xamarin.Kotlin.StdLib => 0x409e66d8 => 108
	i32 1098259244, ; 57: System => 0x41761b2c => 25
	i32 1135815421, ; 58: Microsoft.AspNetCore.Cryptography.KeyDerivation.dll => 0x43b32afd => 13
	i32 1175144683, ; 59: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 94
	i32 1178241025, ; 60: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 81
	i32 1204270330, ; 61: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 45
	i32 1264511973, ; 62: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 90
	i32 1267360935, ; 63: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 95
	i32 1275534314, ; 64: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 111
	i32 1293217323, ; 65: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 60
	i32 1364015309, ; 66: System.IO => 0x514d38cd => 128
	i32 1365406463, ; 67: System.ServiceModel.Internals.dll => 0x516272ff => 122
	i32 1376866003, ; 68: Xamarin.AndroidX.SavedState => 0x52114ed3 => 88
	i32 1395857551, ; 69: Xamarin.AndroidX.Media.dll => 0x5333188f => 78
	i32 1406073936, ; 70: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 54
	i32 1411638395, ; 71: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 30
	i32 1460219004, ; 72: Xamarin.Forms.Xaml => 0x57092c7c => 103
	i32 1462112819, ; 73: System.IO.Compression.dll => 0x57261233 => 118
	i32 1469204771, ; 74: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 43
	i32 1487250139, ; 75: K4os.Hash.xxHash => 0x58a5a2db => 11
	i32 1511525525, ; 76: MySqlConnector => 0x5a180c95 => 20
	i32 1582372066, ; 77: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 59
	i32 1592978981, ; 78: System.Runtime.Serialization.dll => 0x5ef2ee25 => 4
	i32 1622152042, ; 79: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 76
	i32 1624863272, ; 80: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 98
	i32 1635184631, ; 81: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 63
	i32 1636350590, ; 82: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 57
	i32 1639515021, ; 83: System.Net.Http.dll => 0x61b9038d => 3
	i32 1657153582, ; 84: System.Runtime => 0x62c6282e => 31
	i32 1658241508, ; 85: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 92
	i32 1658251792, ; 86: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 104
	i32 1670060433, ; 87: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 53
	i32 1698840827, ; 88: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 107
	i32 1726116996, ; 89: System.Reflection.dll => 0x66e27484 => 127
	i32 1729485958, ; 90: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 49
	i32 1746115085, ; 91: System.IO.Pipelines.dll => 0x68139a0d => 26
	i32 1766324549, ; 92: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 91
	i32 1776026572, ; 93: System.Core.dll => 0x69dc03cc => 23
	i32 1788241197, ; 94: Xamarin.AndroidX.Fragment => 0x6a96652d => 64
	i32 1796167890, ; 95: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 14
	i32 1808609942, ; 96: Xamarin.AndroidX.Loader => 0x6bcd3296 => 76
	i32 1813058853, ; 97: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 108
	i32 1813201214, ; 98: Xamarin.Google.Android.Material => 0x6c13413e => 104
	i32 1818569960, ; 99: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 82
	i32 1820883333, ; 100: Microsoft.AspNetCore.Cryptography.Internal.dll => 0x6c887985 => 12
	i32 1828688058, ; 101: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 15
	i32 1867746548, ; 102: Xamarin.Essentials.dll => 0x6f538cf4 => 99
	i32 1878053835, ; 103: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 103
	i32 1880436471, ; 104: MobileApp.Android.dll => 0x70152ef7 => 0
	i32 1885316902, ; 105: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 46
	i32 1919157823, ; 106: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 79
	i32 1925302748, ; 107: K4os.Compression.LZ4.dll => 0x72c1c9dc => 9
	i32 1983156543, ; 108: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 107
	i32 2011961780, ; 109: System.Buffers.dll => 0x77ec19b4 => 21
	i32 2019465201, ; 110: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 74
	i32 2055257422, ; 111: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 70
	i32 2079903147, ; 112: System.Runtime.dll => 0x7bf8cdab => 31
	i32 2090596640, ; 113: System.Numerics.Vectors => 0x7c9bf920 => 29
	i32 2097448633, ; 114: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 66
	i32 2126786730, ; 115: Xamarin.Forms.Platform.Android => 0x7ec430aa => 101
	i32 2192057212, ; 116: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 15
	i32 2201107256, ; 117: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 112
	i32 2201231467, ; 118: System.Net.Http => 0x8334206b => 3
	i32 2217644978, ; 119: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 94
	i32 2244775296, ; 120: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 77
	i32 2256548716, ; 121: Xamarin.AndroidX.MultiDex => 0x8680336c => 79
	i32 2261435625, ; 122: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 68
	i32 2265110946, ; 123: System.Security.AccessControl.dll => 0x8702d9a2 => 33
	i32 2279755925, ; 124: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 86
	i32 2315684594, ; 125: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 41
	i32 2383496789, ; 126: System.Security.Principal.Windows.dll => 0x8e114655 => 35
	i32 2403452196, ; 127: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 62
	i32 2409053734, ; 128: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 83
	i32 2465532216, ; 129: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 52
	i32 2471841756, ; 130: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 131: Java.Interop.dll => 0x93918882 => 8
	i32 2486824558, ; 132: K4os.Hash.xxHash.dll => 0x9439ee6e => 11
	i32 2498657740, ; 133: BouncyCastle.Cryptography.dll => 0x94ee7dcc => 5
	i32 2501346920, ; 134: System.Data.DataSetExtensions => 0x95178668 => 116
	i32 2505896520, ; 135: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 73
	i32 2570120770, ; 136: System.Text.Encodings.Web => 0x9930ee42 => 36
	i32 2581819634, ; 137: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 95
	i32 2605712449, ; 138: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 112
	i32 2611359322, ; 139: ZstdSharp.dll => 0x9ba62e5a => 113
	i32 2620871830, ; 140: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 57
	i32 2624644809, ; 141: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 61
	i32 2633051222, ; 142: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 71
	i32 2660759594, ; 143: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 123
	i32 2663698177, ; 144: System.Runtime.Loader => 0x9ec4cf01 => 32
	i32 2693849962, ; 145: System.IO.dll => 0xa090e36a => 128
	i32 2701096212, ; 146: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 92
	i32 2732626843, ; 147: Xamarin.AndroidX.Activity => 0xa2e0939b => 40
	i32 2737747696, ; 148: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 43
	i32 2765824710, ; 149: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 2
	i32 2766581644, ; 150: Xamarin.Forms.Core => 0xa4e6af8c => 100
	i32 2770495804, ; 151: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 106
	i32 2778768386, ; 152: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 97
	i32 2779977773, ; 153: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 87
	i32 2810250172, ; 154: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 54
	i32 2819470561, ; 155: System.Xml.dll => 0xa80db4e1 => 38
	i32 2821294376, ; 156: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 87
	i32 2841355853, ; 157: System.Security.Permissions => 0xa95ba64d => 34
	i32 2853208004, ; 158: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 97
	i32 2855708567, ; 159: Xamarin.AndroidX.Transition => 0xaa36a797 => 93
	i32 2867946736, ; 160: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 123
	i32 2901442782, ; 161: System.Reflection => 0xacf080de => 127
	i32 2903344695, ; 162: System.ComponentModel.Composition => 0xad0d8637 => 120
	i32 2905242038, ; 163: mscorlib.dll => 0xad2a79b6 => 18
	i32 2916838712, ; 164: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 98
	i32 2919462931, ; 165: System.Numerics.Vectors.dll => 0xae037813 => 29
	i32 2921128767, ; 166: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 42
	i32 2944313911, ; 167: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 22
	i32 2968338931, ; 168: System.Security.Principal.Windows => 0xb0ed41f3 => 35
	i32 2978675010, ; 169: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 60
	i32 2996846495, ; 170: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 72
	i32 3012788804, ; 171: System.Configuration.ConfigurationManager => 0xb3938244 => 22
	i32 3014607031, ; 172: Microsoft.AspNetCore.Cryptography.KeyDerivation => 0xb3af40b7 => 13
	i32 3016983068, ; 173: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 90
	i32 3024354802, ; 174: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 67
	i32 3025069135, ; 175: K4os.Compression.LZ4.Streams.dll => 0xb44ee44f => 10
	i32 3044182254, ; 176: FormsViewGroup => 0xb57288ee => 6
	i32 3057625584, ; 177: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 80
	i32 3089219899, ; 178: ZstdSharp => 0xb821c13b => 113
	i32 3111772706, ; 179: System.Runtime.Serialization => 0xb979e222 => 4
	i32 3124832203, ; 180: System.Threading.Tasks.Extensions => 0xba4127cb => 126
	i32 3132293585, ; 181: System.Security.AccessControl => 0xbab301d1 => 33
	i32 3204380047, ; 182: System.Data.dll => 0xbefef58f => 114
	i32 3211777861, ; 183: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 59
	i32 3213246214, ; 184: System.Security.Permissions.dll => 0xbf863f06 => 34
	i32 3247949154, ; 185: Mono.Security => 0xc197c562 => 125
	i32 3258312781, ; 186: Xamarin.AndroidX.CardView => 0xc235e84d => 49
	i32 3265893370, ; 187: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 126
	i32 3267021929, ; 188: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 47
	i32 3317135071, ; 189: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 58
	i32 3317144872, ; 190: System.Data => 0xc5b79d28 => 114
	i32 3340431453, ; 191: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 46
	i32 3345895724, ; 192: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 85
	i32 3346324047, ; 193: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 81
	i32 3353484488, ; 194: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 66
	i32 3358260929, ; 195: System.Text.Json => 0xc82afec1 => 37
	i32 3362522851, ; 196: Xamarin.AndroidX.Core => 0xc86c06e3 => 56
	i32 3366347497, ; 197: Java.Interop => 0xc8a662e9 => 8
	i32 3374999561, ; 198: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 86
	i32 3381033598, ; 199: K4os.Compression.LZ4 => 0xc9867a7e => 9
	i32 3395150330, ; 200: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 30
	i32 3404865022, ; 201: System.ServiceModel.Internals => 0xcaf21dfe => 122
	i32 3429136800, ; 202: System.Xml => 0xcc6479a0 => 38
	i32 3430777524, ; 203: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 204: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 61
	i32 3467345667, ; 205: MySql.Data => 0xceab7f03 => 19
	i32 3476120550, ; 206: Mono.Android => 0xcf3163e6 => 17
	i32 3485117614, ; 207: System.Text.Json.dll => 0xcfbaacae => 37
	i32 3486566296, ; 208: System.Transactions => 0xcfd0c798 => 115
	i32 3493954962, ; 209: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 51
	i32 3499097210, ; 210: Google.Protobuf.dll => 0xd08ffc7a => 7
	i32 3501239056, ; 211: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 47
	i32 3509114376, ; 212: System.Xml.Linq => 0xd128d608 => 39
	i32 3515174580, ; 213: System.Security.dll => 0xd1854eb4 => 124
	i32 3536029504, ; 214: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 101
	i32 3567349600, ; 215: System.ComponentModel.Composition.dll => 0xd4a16f60 => 120
	i32 3605570793, ; 216: BouncyCastle.Cryptography => 0xd6e8a4e9 => 5
	i32 3618140916, ; 217: Xamarin.AndroidX.Preference => 0xd7a872f4 => 83
	i32 3627220390, ; 218: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 84
	i32 3632359727, ; 219: Xamarin.Forms.Platform => 0xd881692f => 102
	i32 3633644679, ; 220: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 42
	i32 3641597786, ; 221: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 70
	i32 3645630983, ; 222: Google.Protobuf => 0xd94bea07 => 7
	i32 3672681054, ; 223: Mono.Android.dll => 0xdae8aa5e => 17
	i32 3676310014, ; 224: System.Web.Services.dll => 0xdb2009fe => 121
	i32 3682565725, ; 225: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 48
	i32 3684561358, ; 226: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 51
	i32 3689375977, ; 227: System.Drawing.Common => 0xdbe768e9 => 117
	i32 3706696989, ; 228: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 55
	i32 3718780102, ; 229: Xamarin.AndroidX.Annotation => 0xdda814c6 => 41
	i32 3724971120, ; 230: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 80
	i32 3748608112, ; 231: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 24
	i32 3758932259, ; 232: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 68
	i32 3786282454, ; 233: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 50
	i32 3822602673, ; 234: Xamarin.AndroidX.Media => 0xe3d849b1 => 78
	i32 3829621856, ; 235: System.Numerics.dll => 0xe4436460 => 28
	i32 3885922214, ; 236: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 93
	i32 3888767677, ; 237: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 85
	i32 3896760992, ; 238: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 56
	i32 3920810846, ; 239: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 119
	i32 3921031405, ; 240: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 96
	i32 3931092270, ; 241: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 82
	i32 3945713374, ; 242: System.Data.DataSetExtensions.dll => 0xeb2ecede => 116
	i32 3953953790, ; 243: System.Text.Encoding.CodePages => 0xebac8bfe => 2
	i32 3955647286, ; 244: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 44
	i32 3959773229, ; 245: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 72
	i32 4023392905, ; 246: System.IO.Pipelines => 0xefd01a89 => 26
	i32 4025784931, ; 247: System.Memory => 0xeff49a63 => 27
	i32 4079385022, ; 248: MySqlConnector.dll => 0xf32679be => 20
	i32 4101593132, ; 249: Xamarin.AndroidX.Emoji2 => 0xf479582c => 62
	i32 4105002889, ; 250: Mono.Security.dll => 0xf4ad5f89 => 125
	i32 4151237749, ; 251: System.Core => 0xf76edc75 => 23
	i32 4182413190, ; 252: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 75
	i32 4185676441, ; 253: System.Security => 0xf97c5a99 => 124
	i32 4213026141, ; 254: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 24
	i32 4256097574, ; 255: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 55
	i32 4260525087, ; 256: System.Buffers => 0xfdf2741f => 21
	i32 4292120959 ; 257: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 75
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [258 x i32] [
	i32 73, i32 105, i32 100, i32 12, i32 89, i32 89, i32 109, i32 50, ; 0..7
	i32 91, i32 48, i32 0, i32 67, i32 121, i32 53, i32 71, i32 65, ; 8..15
	i32 40, i32 28, i32 69, i32 27, i32 52, i32 99, i32 64, i32 18, ; 16..23
	i32 25, i32 65, i32 77, i32 115, i32 109, i32 14, i32 119, i32 10, ; 24..31
	i32 58, i32 63, i32 36, i32 96, i32 45, i32 39, i32 111, i32 106, ; 32..39
	i32 110, i32 32, i32 16, i32 118, i32 117, i32 16, i32 84, i32 105, ; 40..47
	i32 110, i32 69, i32 6, i32 19, i32 88, i32 44, i32 102, i32 74, ; 48..55
	i32 108, i32 25, i32 13, i32 94, i32 81, i32 45, i32 90, i32 95, ; 56..63
	i32 111, i32 60, i32 128, i32 122, i32 88, i32 78, i32 54, i32 30, ; 64..71
	i32 103, i32 118, i32 43, i32 11, i32 20, i32 59, i32 4, i32 76, ; 72..79
	i32 98, i32 63, i32 57, i32 3, i32 31, i32 92, i32 104, i32 53, ; 80..87
	i32 107, i32 127, i32 49, i32 26, i32 91, i32 23, i32 64, i32 14, ; 88..95
	i32 76, i32 108, i32 104, i32 82, i32 12, i32 15, i32 99, i32 103, ; 96..103
	i32 0, i32 46, i32 79, i32 9, i32 107, i32 21, i32 74, i32 70, ; 104..111
	i32 31, i32 29, i32 66, i32 101, i32 15, i32 112, i32 3, i32 94, ; 112..119
	i32 77, i32 79, i32 68, i32 33, i32 86, i32 41, i32 35, i32 62, ; 120..127
	i32 83, i32 52, i32 1, i32 8, i32 11, i32 5, i32 116, i32 73, ; 128..135
	i32 36, i32 95, i32 112, i32 113, i32 57, i32 61, i32 71, i32 123, ; 136..143
	i32 32, i32 128, i32 92, i32 40, i32 43, i32 2, i32 100, i32 106, ; 144..151
	i32 97, i32 87, i32 54, i32 38, i32 87, i32 34, i32 97, i32 93, ; 152..159
	i32 123, i32 127, i32 120, i32 18, i32 98, i32 29, i32 42, i32 22, ; 160..167
	i32 35, i32 60, i32 72, i32 22, i32 13, i32 90, i32 67, i32 10, ; 168..175
	i32 6, i32 80, i32 113, i32 4, i32 126, i32 33, i32 114, i32 59, ; 176..183
	i32 34, i32 125, i32 49, i32 126, i32 47, i32 58, i32 114, i32 46, ; 184..191
	i32 85, i32 81, i32 66, i32 37, i32 56, i32 8, i32 86, i32 9, ; 192..199
	i32 30, i32 122, i32 38, i32 1, i32 61, i32 19, i32 17, i32 37, ; 200..207
	i32 115, i32 51, i32 7, i32 47, i32 39, i32 124, i32 101, i32 120, ; 208..215
	i32 5, i32 83, i32 84, i32 102, i32 42, i32 70, i32 7, i32 17, ; 216..223
	i32 121, i32 48, i32 51, i32 117, i32 55, i32 41, i32 80, i32 24, ; 224..231
	i32 68, i32 50, i32 78, i32 28, i32 93, i32 85, i32 56, i32 119, ; 232..239
	i32 96, i32 82, i32 116, i32 2, i32 44, i32 72, i32 26, i32 27, ; 240..247
	i32 20, i32 62, i32 125, i32 23, i32 75, i32 124, i32 24, i32 55, ; 248..255
	i32 21, i32 75 ; 256..257
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
