using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecrypt
{
    /* Volume types */
    public enum VolumeType
    {
	    TC_VOLUME_TYPE_NORMAL = 0,
	    TC_VOLUME_TYPE_HIDDEN,
	    TC_VOLUME_TYPE_HIDDEN_LEGACY,
	    TC_VOLUME_TYPE_COUNT
    };

    /* Prop volume types */
    public enum VolumeTypeProp
    {
	    PROP_VOL_TYPE_NORMAL = 0,
	    PROP_VOL_TYPE_HIDDEN,
	    PROP_VOL_TYPE_OUTER,						/* Outer/normal (hidden volume protected) */
	    PROP_VOL_TYPE_OUTER_VOL_WRITE_PREVENTED,	/* Outer/normal (hidden volume protected AND write already prevented) */
	    PROP_VOL_TYPE_SYSTEM,
	    PROP_NBR_VOLUME_TYPES
    };

    /* Hidden volume protection status */
    public enum HiddenVolumeProtectionStat
    {
	    HIDVOL_PROT_STATUS_NONE = 0,
	    HIDVOL_PROT_STATUS_ACTIVE,
	    HIDVOL_PROT_STATUS_ACTION_TAKEN			/* Active + action taken (write operation has already been denied) */
    };


    public struct MountOptions
    {
        public bool ReadOnly;
        public bool Removable;
        public bool ProtectHiddenVolume;
        public bool PreserveTimestamp;
        public bool PartitionInInactiveSysEncScope;	/* If TRUE, we are to attempt to mount a partition located on an encrypted system drive without pre-boot authentication. */
        string ProtectedHidVolPassword;	/* Password of hidden volume to protect against overwriting */
        public bool UseBackupHeader;
        public bool RecoveryMode;
    }

    class Common
    {

        //void so far :D
    }
}
