﻿/*
 * .NET bindings for libheif.
 * Copyright (c) 2020 Nicholas Hayes
 *
 * Portions Copyright (c) 2017 struktur AG, Dirk Farin <farin@struktur.de>
 *
 * This file is part of libheif-sharp.
 *
 * libheif-sharp is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version.
 *
 * libheif-sharp is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with libheif-sharp.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace LibHeifSharp
{
    internal static class LibHeifVersion
    {
        /// <summary>
        /// Throws an exception if the LibHeif version is not supported.
        /// </summary>
        /// <exception cref="HeifException">The LibHeif version is not supported.</exception>
        public static void ThrowIfNotSupported()
        {
            const uint MinimumLibHeifVersion = 0x01090000; // Version 1.9.0

            if (LibHeifInfo.VersionNumber < MinimumLibHeifVersion)
            {
                const int Major = (int)((MinimumLibHeifVersion >> 24) & 0xff);
                const int Minor = (int)((MinimumLibHeifVersion >> 16) & 0xff);
                const int Maintenance = (int)((MinimumLibHeifVersion >> 8) & 0xff);

                throw new HeifException(string.Format(System.Globalization.CultureInfo.CurrentCulture,
                                                      Properties.Resources.LibHeifVersionNotSupportedFormat,
                                                      Major,
                                                      Minor,
                                                      Maintenance));
            }
        }
    }
}
