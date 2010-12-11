using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.TrueCrypt
{
    public class TrueCryptAPI
    {
        // Volume header sizes
        public const int TC_VOLUME_HEADER_SIZE =	(64 * 1024);
        public const int TC_VOLUME_HEADER_EFFECTIVE_SIZE =	512;
        public const int TC_BOOT_ENCRYPTION_VOLUME_HEADER_SIZE	= 512;
        public const int TC_VOLUME_HEADER_SIZE_LEGACY = 512;

        public const int TC_VOLUME_HEADER_GROUP_SIZE = (2 * TC_VOLUME_HEADER_SIZE);
        public const int TC_TOTAL_VOLUME_HEADERS_SIZE = (4 * TC_VOLUME_HEADER_SIZE);

        // Volume offsets
        public const int TC_VOLUME_HEADER_OFFSET = 0;
        public const int TC_HIDDEN_VOLUME_HEADER_OFFSET = TC_VOLUME_HEADER_SIZE;

        // Sector sizes
        public const int TC_MIN_VOLUME_SECTOR_SIZE = 512;
        public const int TC_MAX_VOLUME_SECTOR_SIZE = 4096;
        public const int TC_SECTOR_SIZE_FILE_HOSTED_VOLUME = 512;
        public const int TC_SECTOR_SIZE_LEGACY = 512;
    }
}
