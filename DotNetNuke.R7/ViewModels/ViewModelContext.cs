﻿//
//  ViewModelContext.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2016 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Web.UI;
using DotNetNuke.UI.Modules;

namespace DotNetNuke.R7.ViewModels
{
    public class ViewModelContext
    {
        public string LocalResourceFile { get; protected set; }

        public ModuleInstanceContext Module { get; protected set; }

        public ViewModelContext (IModuleControl module)
        {
            Module = module.ModuleContext;
            LocalResourceFile = module.LocalResourceFile;
        }

        public ViewModelContext (Control control, IModuleControl module)
        {
            Module = module.ModuleContext;
            LocalResourceFile = DotNetNuke.Web.UI.Utilities.GetLocalResourceFile (control);
        }
    }
}
