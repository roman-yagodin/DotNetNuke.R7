﻿//
//  UrlHistoryBackend.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017 Roman M. Yagodin
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

using System.Collections.Generic;
using System.Web.SessionState;

namespace R7.Dnn.Extensions.UrlHistory
{
    /// <summary>
    /// Abstract backend for UrlHistory
    /// </summary>
    public abstract class UrlHistoryBackend
    {
        public abstract void Init (HttpSessionState session, string variableName);

        public abstract void StoreUrl (string url);

        public abstract IEnumerable<string> GetUrls ();
    }
}
