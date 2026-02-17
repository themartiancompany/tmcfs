#!/usr/bin/env node

// SPDX-License-Identifier: AGPL-3.0-or-later

/**    ----------------------------------------------------------------------
 *     Copyright ©
 *       Pellegrino Prevete
 *         2025, 2026
 * 
 *     All rights reserved
 *     ----------------------------------------------------------------------
 * 
 *     This program is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 * 
 *     This program is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 * 
 *     You should have received a copy of the GNU General Public License
 *     along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

function
  _opfs_module_get() {
    let
      _fs;
    try {
      _fs =
        require("opfs");
    }
    catch(
      _error) {
      console.log(
        _error);
      const
        _msg =
          "Error importing the " +
          "'@themartiancompany/opfs' module " +
          "as 'opfs'. If you got this error " +
          "while bundling a webpack for a project " +
          "depending on this module double check its " +
          "'webpack.config.js' file or whether the " +
          "'opfs' module is listed in developer " +
          "dependencies and install them." +
          "I'm sorry for this inconvenience but " +
          "Node packagement system does not currently",
          "distinguish 'development' from 'build'",
          "dependencies.";
      console.error(
        _msg);
      throw _error;
    }
    return _fs;
}

function
  _fs_module_auto_detect() {
    let
      _fs;
    if ( typeof window === 'undefined' &&
         ( typeof global !== 'undefined' && global.global === global ) &&
         typeof __webpack_require__ !== 'function' ) {
      _fs =
        require(
          "fs");
    }
    else {
      _fs =
        _opfs_module_get();
    }
    return _fs;
}

function
  _fs_module_get(
    _module_type) {
    let
      _fs;
    if ( _module_name == "" ||
         typeof _module_name === 'undefined' ) {
      _fs =
        _fs_module_auto_detect();
    }
    else if ( _module_name == 'opfs' ) {
      _fs =
        require(
          "opfs");
    }
    else if ( _module_name == 'fs' ) {
      _fs =
        require(
          "fs");
    }
    else {
      const
        _msg =
          "Unknown file system module " +
          `'${_module_name}'.`.
      const
        _error =
        { "msg":
            _msg };
      console.error(
        _msg);
      throw _error
    }
    return _fs;
}

const
  _fs =
    _fs_module_auto_detect();

module.exports =
  _fs;
module.exports.getModule =
  _fs_module_get;
