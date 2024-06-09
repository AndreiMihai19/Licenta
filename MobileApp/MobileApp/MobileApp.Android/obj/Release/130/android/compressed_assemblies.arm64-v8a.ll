; ModuleID = 'obj\Release\130\android\compressed_assemblies.arm64-v8a.ll'
source_filename = "obj\Release\130\android\compressed_assemblies.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [6846464 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [16384 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [459264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [168960 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [79360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [66560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [12800 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [34816 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [14848 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [8704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [54784 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [440320 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [114176 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [2487296 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [121856 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [1173504 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [805376 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [14768 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [364544 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [370688 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [857088 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_21 = internal global [147456 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_22 = internal global [26112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_23 = internal global [72704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_24 = internal global [218112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_25 = internal global [35840 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_26 = internal global [8192 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_27 = internal global [5120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_28 = internal global [419328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_29 = internal global [11776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_30 = internal global [79872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_31 = internal global [8704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_32 = internal global [6144 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_33 = internal global [55808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_34 = internal global [5120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_35 = internal global [68096 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_36 = internal global [557568 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_37 = internal global [15296 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_38 = internal global [10752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_39 = internal global [1089024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_40 = internal global [974848 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_41 = internal global [64512 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_42 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_43 = internal global [530432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_44 = internal global [17920 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_45 = internal global [79360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_46 = internal global [635904 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_47 = internal global [25600 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_48 = internal global [9728 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_49 = internal global [44544 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_50 = internal global [201216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_51 = internal global [15872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_52 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_53 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_54 = internal global [20480 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_55 = internal global [37376 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_56 = internal global [424448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_57 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_58 = internal global [40448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_59 = internal global [58368 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_60 = internal global [26112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_61 = internal global [1219072 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_62 = internal global [1046528 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_63 = internal global [349216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_64 = internal global [103936 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_65 = internal global [258048 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_66 = internal global [23432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_67 = internal global [152984 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_68 = internal global [15256 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_69 = internal global [15256 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_70 = internal global [15240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_71 = internal global [2214288 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_72 = internal global [26512 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_73 = internal global [317320 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_74 = internal global [436736 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_75 = internal global [2222080 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [76 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 6846464, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([6846464 x i8], [6846464 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 16384, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16384 x i8], [16384 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 459264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([459264 x i8], [459264 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 168960, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([168960 x i8], [168960 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 79360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([79360 x i8], [79360 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 66560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([66560 x i8], [66560 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 12800, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([12800 x i8], [12800 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 34816, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34816 x i8], [34816 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14848 x i8], [14848 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 54784, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([54784 x i8], [54784 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 440320, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([440320 x i8], [440320 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 114176, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([114176 x i8], [114176 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 2487296, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2487296 x i8], [2487296 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([121856 x i8], [121856 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 1173504, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1173504 x i8], [1173504 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 805376, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([805376 x i8], [805376 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 14768, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14768 x i8], [14768 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 364544, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([364544 x i8], [364544 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 370688, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([370688 x i8], [370688 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 857088, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([857088 x i8], [857088 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 147456, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([147456 x i8], [147456 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26112 x i8], [26112 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 72704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([72704 x i8], [72704 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 218112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([218112 x i8], [218112 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 35840, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([35840 x i8], [35840 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8192 x i8], [8192 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}, 
	; 28
	%struct.CompressedAssemblyDescriptor {
		i32 419328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([419328 x i8], [419328 x i8]* @__CompressedAssemblyDescriptor_data_28, i32 0, i32 0); data
	}, 
	; 29
	%struct.CompressedAssemblyDescriptor {
		i32 11776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([11776 x i8], [11776 x i8]* @__CompressedAssemblyDescriptor_data_29, i32 0, i32 0); data
	}, 
	; 30
	%struct.CompressedAssemblyDescriptor {
		i32 79872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([79872 x i8], [79872 x i8]* @__CompressedAssemblyDescriptor_data_30, i32 0, i32 0); data
	}, 
	; 31
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_31, i32 0, i32 0); data
	}, 
	; 32
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([6144 x i8], [6144 x i8]* @__CompressedAssemblyDescriptor_data_32, i32 0, i32 0); data
	}, 
	; 33
	%struct.CompressedAssemblyDescriptor {
		i32 55808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([55808 x i8], [55808 x i8]* @__CompressedAssemblyDescriptor_data_33, i32 0, i32 0); data
	}, 
	; 34
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_34, i32 0, i32 0); data
	}, 
	; 35
	%struct.CompressedAssemblyDescriptor {
		i32 68096, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([68096 x i8], [68096 x i8]* @__CompressedAssemblyDescriptor_data_35, i32 0, i32 0); data
	}, 
	; 36
	%struct.CompressedAssemblyDescriptor {
		i32 557568, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([557568 x i8], [557568 x i8]* @__CompressedAssemblyDescriptor_data_36, i32 0, i32 0); data
	}, 
	; 37
	%struct.CompressedAssemblyDescriptor {
		i32 15296, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15296 x i8], [15296 x i8]* @__CompressedAssemblyDescriptor_data_37, i32 0, i32 0); data
	}, 
	; 38
	%struct.CompressedAssemblyDescriptor {
		i32 10752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([10752 x i8], [10752 x i8]* @__CompressedAssemblyDescriptor_data_38, i32 0, i32 0); data
	}, 
	; 39
	%struct.CompressedAssemblyDescriptor {
		i32 1089024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1089024 x i8], [1089024 x i8]* @__CompressedAssemblyDescriptor_data_39, i32 0, i32 0); data
	}, 
	; 40
	%struct.CompressedAssemblyDescriptor {
		i32 974848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([974848 x i8], [974848 x i8]* @__CompressedAssemblyDescriptor_data_40, i32 0, i32 0); data
	}, 
	; 41
	%struct.CompressedAssemblyDescriptor {
		i32 64512, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([64512 x i8], [64512 x i8]* @__CompressedAssemblyDescriptor_data_41, i32 0, i32 0); data
	}, 
	; 42
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_42, i32 0, i32 0); data
	}, 
	; 43
	%struct.CompressedAssemblyDescriptor {
		i32 530432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([530432 x i8], [530432 x i8]* @__CompressedAssemblyDescriptor_data_43, i32 0, i32 0); data
	}, 
	; 44
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([17920 x i8], [17920 x i8]* @__CompressedAssemblyDescriptor_data_44, i32 0, i32 0); data
	}, 
	; 45
	%struct.CompressedAssemblyDescriptor {
		i32 79360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([79360 x i8], [79360 x i8]* @__CompressedAssemblyDescriptor_data_45, i32 0, i32 0); data
	}, 
	; 46
	%struct.CompressedAssemblyDescriptor {
		i32 635904, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([635904 x i8], [635904 x i8]* @__CompressedAssemblyDescriptor_data_46, i32 0, i32 0); data
	}, 
	; 47
	%struct.CompressedAssemblyDescriptor {
		i32 25600, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25600 x i8], [25600 x i8]* @__CompressedAssemblyDescriptor_data_47, i32 0, i32 0); data
	}, 
	; 48
	%struct.CompressedAssemblyDescriptor {
		i32 9728, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([9728 x i8], [9728 x i8]* @__CompressedAssemblyDescriptor_data_48, i32 0, i32 0); data
	}, 
	; 49
	%struct.CompressedAssemblyDescriptor {
		i32 44544, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([44544 x i8], [44544 x i8]* @__CompressedAssemblyDescriptor_data_49, i32 0, i32 0); data
	}, 
	; 50
	%struct.CompressedAssemblyDescriptor {
		i32 201216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([201216 x i8], [201216 x i8]* @__CompressedAssemblyDescriptor_data_50, i32 0, i32 0); data
	}, 
	; 51
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15872 x i8], [15872 x i8]* @__CompressedAssemblyDescriptor_data_51, i32 0, i32 0); data
	}, 
	; 52
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_52, i32 0, i32 0); data
	}, 
	; 53
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_53, i32 0, i32 0); data
	}, 
	; 54
	%struct.CompressedAssemblyDescriptor {
		i32 20480, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([20480 x i8], [20480 x i8]* @__CompressedAssemblyDescriptor_data_54, i32 0, i32 0); data
	}, 
	; 55
	%struct.CompressedAssemblyDescriptor {
		i32 37376, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([37376 x i8], [37376 x i8]* @__CompressedAssemblyDescriptor_data_55, i32 0, i32 0); data
	}, 
	; 56
	%struct.CompressedAssemblyDescriptor {
		i32 424448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([424448 x i8], [424448 x i8]* @__CompressedAssemblyDescriptor_data_56, i32 0, i32 0); data
	}, 
	; 57
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_57, i32 0, i32 0); data
	}, 
	; 58
	%struct.CompressedAssemblyDescriptor {
		i32 40448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([40448 x i8], [40448 x i8]* @__CompressedAssemblyDescriptor_data_58, i32 0, i32 0); data
	}, 
	; 59
	%struct.CompressedAssemblyDescriptor {
		i32 58368, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([58368 x i8], [58368 x i8]* @__CompressedAssemblyDescriptor_data_59, i32 0, i32 0); data
	}, 
	; 60
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26112 x i8], [26112 x i8]* @__CompressedAssemblyDescriptor_data_60, i32 0, i32 0); data
	}, 
	; 61
	%struct.CompressedAssemblyDescriptor {
		i32 1219072, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1219072 x i8], [1219072 x i8]* @__CompressedAssemblyDescriptor_data_61, i32 0, i32 0); data
	}, 
	; 62
	%struct.CompressedAssemblyDescriptor {
		i32 1046528, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1046528 x i8], [1046528 x i8]* @__CompressedAssemblyDescriptor_data_62, i32 0, i32 0); data
	}, 
	; 63
	%struct.CompressedAssemblyDescriptor {
		i32 349216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([349216 x i8], [349216 x i8]* @__CompressedAssemblyDescriptor_data_63, i32 0, i32 0); data
	}, 
	; 64
	%struct.CompressedAssemblyDescriptor {
		i32 103936, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([103936 x i8], [103936 x i8]* @__CompressedAssemblyDescriptor_data_64, i32 0, i32 0); data
	}, 
	; 65
	%struct.CompressedAssemblyDescriptor {
		i32 258048, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([258048 x i8], [258048 x i8]* @__CompressedAssemblyDescriptor_data_65, i32 0, i32 0); data
	}, 
	; 66
	%struct.CompressedAssemblyDescriptor {
		i32 23432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([23432 x i8], [23432 x i8]* @__CompressedAssemblyDescriptor_data_66, i32 0, i32 0); data
	}, 
	; 67
	%struct.CompressedAssemblyDescriptor {
		i32 152984, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([152984 x i8], [152984 x i8]* @__CompressedAssemblyDescriptor_data_67, i32 0, i32 0); data
	}, 
	; 68
	%struct.CompressedAssemblyDescriptor {
		i32 15256, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15256 x i8], [15256 x i8]* @__CompressedAssemblyDescriptor_data_68, i32 0, i32 0); data
	}, 
	; 69
	%struct.CompressedAssemblyDescriptor {
		i32 15256, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15256 x i8], [15256 x i8]* @__CompressedAssemblyDescriptor_data_69, i32 0, i32 0); data
	}, 
	; 70
	%struct.CompressedAssemblyDescriptor {
		i32 15240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15240 x i8], [15240 x i8]* @__CompressedAssemblyDescriptor_data_70, i32 0, i32 0); data
	}, 
	; 71
	%struct.CompressedAssemblyDescriptor {
		i32 2214288, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2214288 x i8], [2214288 x i8]* @__CompressedAssemblyDescriptor_data_71, i32 0, i32 0); data
	}, 
	; 72
	%struct.CompressedAssemblyDescriptor {
		i32 26512, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26512 x i8], [26512 x i8]* @__CompressedAssemblyDescriptor_data_72, i32 0, i32 0); data
	}, 
	; 73
	%struct.CompressedAssemblyDescriptor {
		i32 317320, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([317320 x i8], [317320 x i8]* @__CompressedAssemblyDescriptor_data_73, i32 0, i32 0); data
	}, 
	; 74
	%struct.CompressedAssemblyDescriptor {
		i32 436736, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([436736 x i8], [436736 x i8]* @__CompressedAssemblyDescriptor_data_74, i32 0, i32 0); data
	}, 
	; 75
	%struct.CompressedAssemblyDescriptor {
		i32 2222080, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2222080 x i8], [2222080 x i8]* @__CompressedAssemblyDescriptor_data_75, i32 0, i32 0); data
	}
], align 8; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 76, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([76 x %struct.CompressedAssemblyDescriptor], [76 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 8


!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
