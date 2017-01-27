Civ 6 Mod Manager v0.7 Experimental
===================================

Overview
--------

This is an experimental application to:

- Create "Mod Sets", single mods that merge others mods together to attempt to resolve incompatibilities and provide single-click on and off for groups of mods;
- Provide enabling/disabling of mods in a way that honors the <Blocks> element;
- Allow hiding of mods that have been included in mod sets or that you just don't want to see in game;
- Allow simplified viewing of existing mods with easy difference viewing of imported base asset files so changes can easily be seen.
- Allow adding/removing active mods in saved games by editing their Mod Set.

This experimental version is being released for testing to see if the auto-merging is accurate enough to be generally useful.  While anyone is free to use it, the initial target audience is Civ 6 modders who may be able to help diagnose any issues they discover.

Mod Sets
--------

To create a Mod Set, select <New Mod Set> on the main screen, enter a name, and add the mods you wish to include.

For compatibility with some mods that alter DLC artdefs, it is a good idea to include DLC in the Mod Set.

When you click OK, ModManager does the follow:

- Adjusts the order of the mods you have selected such that any Referenced mod comes before any mod that <References> it;
- Adjusts the order of components across all the mods based on <LoadOrder> followed by mod order;
- Adds all the components to the new mod in order, copying and merging files as necessary.

Dep and ArtDef files are merged automatically through code that understands their file formats, with the last component to modify a specific object (say, a UNIT_SETTLER) overwriting previous changes to that same object.

An automatic merge 3-way or 2-way merge is attempted on conflicting Imported files depending on if they exist in the games base assets folder (3-way if they do, 2-way if not).  If a conflict that cannot be resolved automatically is detected, kdiff3 is used to manually resolve the differences.

You can change the default behaviors of the merge or use your preferred merging program by clicking <Options> on the Mod Set window.

You can edit Mod Sets.  This will affect saved games using the Mod Set, so it can be used to add or remove mods from a saved game.  Note this could be a bad idea for some mods, however--you wouldn't want to remove a mod that created the civ you are currently playing, for instance.

Limitations/Future Work
-----------------------

- Currently may not work properly with custom <Ruleset>'s;
- Experimental version to see if it works widely and is generally useful;
- Plan to have Mod Manager automatically recognize and offer to merge changes to included mods;
- May expand View Mod to a full Mod Creation/Editing tool.

Change Log
----------

v0.2
- Fixed crash on non-existent files in .modinfo;
- Generated XML files now properly declare UTF-8 instead of UTF-16;
- Save settings to .xml file instead of registry;
- Install application creates desktop shortcut;

v0.3
- Fixed "Cannot insert the node at the specificed location" bug added in v0.2

v0.4
- Fixed bug with mods containing spaces and/or starting with a number--apparently component Id's in .modinfo have to start with a letter and contain no spaces.
- Fixed bug with .NET DOM not properly trimming XML text values (affected "Current Time Of Day" mod).

v0.5
- Will prompt for Civ 6 directory if it can't find it through Steam.

v0.6
- Added ability to edit Mod Sets.  This will affect saved games using the Mod Set, so it can be used to add or remove mods from a saved game.  Note this could be a bad idea for some mods, however--you wouldn't want to remove a mod that created the civ you are currently playing, for instance.

v0.7
- Fixed "Edit Set" to only edit Mod Sets (was allowing editing of normal mods).
- Fixed "Edit Set" to rebuild <Blocks>, etc.

3rd Party Tools/Code/Etc.
-------------------------

The following open source 3rd party tools/code/etc. have been used:

SynchrotonNet.Diff.cs:
  Copyright (c) 2006, 2008 Tony Garnock-Jones <tonyg@lshift.net>
  Copyright (c) 2006, 2008 LShift Ltd. <query@lshift.net>
  https://gist.github.com/TaoK/2633407

Kdiff3 (Optionally installed and shelled to)
  Copyright: (c) 2002-2014 by Joachim Eibl
  http://kdiff3.sourceforge.net/

Sqlite.cs:
  Copyright (c) 2009-2016 Krueger Systems, Inc.
  https://github.com/praeclarum/sqlite-net/blob/master/src/SQLite.cs

SQLite (64-bit sqlite3.dll)
  Donated to the Public Domain by Hipp, Wyrick & Company, Inc., et al
  https://www.sqlite.org/amalgamation.html
  https://www.sqlite.org/index.html
  
ScintillaNet.3.5.10
  Copyright (c) 2016, Jacob Slusser
  https://github.com/jacobslusser/ScintillaNET

Scintilla (used in DLL form by ScintillaNet)
  Copyright 1998-2002 by Neil Hodgson
  http://www.scintilla.org/

Nullsoft Scriptable Install System (NSIS) (for installation exe)
  Copyright (C) 1999-2017 Contributors
  http://nsis.sourceforge.net/Main_Page

License
-------

MIT License

Copyright (c) 2017 PlotinusRedux

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.


