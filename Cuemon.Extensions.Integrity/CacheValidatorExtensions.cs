﻿using System;
using System.IO;
using System.Reflection;
using Cuemon.Integrity;
using Cuemon.IO;

namespace Cuemon.Extensions.Integrity
{
    /// <summary>
    /// This is an extension implementation of the most common methods on the <see cref="CacheValidator"/> class.
    /// </summary>
    public static class CacheValidatorExtensions
    {
        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="Double"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, double checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }


        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="Int16"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, short checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="String"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, string checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="Int32"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, int checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="Int64"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, long checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="Single"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, float checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="UInt16"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, ushort checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="UInt32"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, uint checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">A <see cref="UInt64"/> value containing a byte-for-byte checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, ulong checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified parameters.
        /// </summary>
        /// <param name="created">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was first created.</param>
        /// <param name="modified">A <see cref="DateTime"/> value for when data this <see cref="CacheValidator"/> represents was last modified.</param>
        /// <param name="checksum">An array of bytes containing a checksum of the data this <see cref="CacheValidator"/> represents.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that fully represents the integrity of the specified parameters.</returns>
        public static CacheValidator GetCacheValidator(this DateTime created, DateTime modified, byte[] checksum, Action<CacheValidatorOptions> setup = null)
        {
            return new CacheValidator(created, modified, checksum, setup);
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified <paramref name="fileinfo"/>.
        /// </summary>
        /// <param name="fileinfo">The fully qualified name of the file.</param>
        /// <param name="bytesToRead">The maximum size of a byte-for-byte that promotes a medium/strong integrity check of the specified <paramref name="fileinfo"/>. A value of 0 (or less) leaves the integrity check at weak.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions"/> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator"/> that represents either a weak, medium or strong integrity check of the specified <paramref name="fileinfo"/>.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="fileinfo"/> is null.
        /// </exception>
        /// <remarks>Should the specified <paramref name="fileinfo"/> trigger any sort of exception, a <see cref="CacheValidator.Default"/> is returned.</remarks>
        public static CacheValidator GetCacheValidator(this FileInfo fileinfo, Action<FileChecksumOptions> setup = null)
        {
            Validator.ThrowIfNull(fileinfo, nameof(fileinfo));
            try
            {
                return CacheValidator.FromFileInfo(fileinfo, setup);
            }
            catch (Exception)
            {
                return CacheValidator.Default;
            }
        }

        /// <summary>
        /// Returns a <see cref="CacheValidator"/> from the specified <paramref name="assembly" />.
        /// </summary>
        /// <param name="assembly">The assembly to resolve a <see cref="CacheValidator" /> from.</param>
        /// <param name="readByteForByteChecksum"><c>true</c> to read the <paramref name="assembly"/> byte-for-byte to promote a strong integrity checksum; <c>false</c> to read common properties of the <paramref name="assembly"/> for a weak (but reliable) integrity checksum.</param>
        /// <param name="setup">The <see cref="CacheValidatorOptions" /> which need to be configured.</param>
        /// <returns>A <see cref="CacheValidator" /> that fully represents the integrity of the specified <paramref name="assembly" />.</returns>
        public static CacheValidator GetCacheValidator(this Assembly assembly, bool readByteForByteChecksum = false, Action<CacheValidatorOptions> setup = null)
        {
            if (assembly == null || assembly.IsDynamic) { return CacheValidator.Default; }
            var assemblyHashCode64 = assembly.FullName.GetHashCode64();
            var assemblyLocation = assembly.Location;
            return assemblyLocation.IsNullOrEmpty() ? new CacheValidator(DateTime.MinValue, DateTime.MaxValue, assemblyHashCode64, setup) : GetCacheValidator(new FileInfo(assemblyLocation), Patterns.ConfigureExchange<CacheValidatorOptions, FileChecksumOptions>(setup, (cvo, fco) => 
            {
                fco.BytesToRead = readByteForByteChecksum ? int.MaxValue : 0;
                fco.Algorithm = cvo.Algorithm;
                fco.Method = cvo.Method;
            })).CombineWith(assemblyHashCode64);
        }
    }
}