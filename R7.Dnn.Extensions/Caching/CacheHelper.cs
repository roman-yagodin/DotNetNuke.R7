﻿//
//  CacheHelper.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016-2018 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.ObjectModel;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Cache;

namespace R7.Dnn.Extensions.Caching
{
    public static class CacheHelper
    {
        /// <summary>
        /// Remove all cache keys with specified prefix
        /// </summary>
        /// <param name="cacheKeyPrefix">Cache key prefix.</param>
        public static void RemoveCacheByPrefix (string cacheKeyPrefix)
        {
            var cacheKeysToRemove = new Collection<string> ();
            var cacheEnumerator = CachingProvider.Instance ().GetEnumerator ();

            while (cacheEnumerator.MoveNext ()) {
                var cacheKey = cacheEnumerator.Key.ToString ();
                if (cacheKey.StartsWith ("DNN_" + cacheKeyPrefix, StringComparison.InvariantCultureIgnoreCase)) {
                    cacheKeysToRemove.Add (cacheKey);
                }
            }

            foreach (var cacheKey in cacheKeysToRemove) {
                // Substring (4) removes DNN_ prefix 
                DataCache.RemoveCache (cacheKey.Substring (4));
            }
        }

        public static DNNCacheDependency GetDNNCacheDependency (string cacheKey)
        {
            return new DNNCacheDependency (null, new string [] { cacheKey });
        }

        public static void EnsureRootExists (string cacheKey, int seconds)
        {
            if (DataCache.GetCache (cacheKey) == null) {
                // use sliding expiration for root cache object
                // to ensure that it will be in cache for subsequent cache operations
                // TODO: Increase cache priority?
                DataCache.SetCache (cacheKey, new object (), TimeSpan.FromSeconds (seconds));
            }
        }
    }
}
