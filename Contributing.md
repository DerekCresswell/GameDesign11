# Contributing

Thank you for your interest in building this repository!\
Please read through this before submitting [issues](#issues) and [pull requests](#pull-requests). Also contained are the [guidelines to follow](#guidelines) when writing material.

## Issues

Before beginning to work on an [issue](https://github.com/DerekCresswell/GameDesign11/issues) please comment on the issue and ask if the work is still needed and up for grabs. This will prevent duplicate work and save everyone time.

Please check the issues for duplicates before making a new one.\
For [submitting new issues](https://github.com/DerekCresswell/GameDesign11/issues/new) there are a few other things :

* For students, if you don't understand a concept or like the way it was explained please make an issue and specifically reference the area which caused the struggle. Please also include as much detail as to why it did not work. If you can look elsewhere and find out how the concept really works before submitting an issue please do. This can make it easier to discover what was wrong with an explanation.\
Click [here](https://github.com/DerekCresswell/GameDesign11/issues/new) to start a new issue. Please remember to give as much detail as possible.

* For writers, please include all details that are relevant to the topic. If you are adding a request for a new section please explain why it is important and where it will fit in. For issues regarding typos / small fixes try and group a few together or comment on a larger issue of the same kind to reduce the overall number of issues.

## Pull Requests

[Pull requests](https://github.com/DerekCresswell/GameDesign11/pulls) should be constrained to a single [issue](#issues) or addition. Please mention the issues in the title or body of the request.\
Do not add extra things to a PR that do not pertain to its main topic.\
The [guidelines](#guidelines) need to followed for choice of language, linking, and markdown formatting.\
If you are unsure about the quality of a PR just ask for a stricter review. If you have questions about the purpose of a PR please ask with / in an issue.

## Adding Scripts

If you have a helpful script and want to add it to the repo you can create an [issue](#issues) / [pull request](#pull-requests) like above to add it to the appropriate library folder.\
The script must also contain the following at the top : 

```csharp
/*
 * ___________________________________________________
 * 
 *                     GameDesign11 
 * ___________________________________________________
 *  An intro to 2D Game Design using the Unity Engine
 * 
 * Author: Derek Cresswell & Contributors
 * https://github.com/DerekCresswell/GameDesign11
 * 
 * Add a description about what this script will do.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Add any instructions here about how to set up
 * the script, object, or others.
 * Feel free to leave something a little broken so
 * students need to fix it.
 *
 */
```

Scripts will not be accepted without this.\
This must be above everything else in the script. Add in an appropriate description and instructions. Follow the [guidelines](#guidelines) below when writing those.\
Also ensure that the syntax of your code is written with the [syntax of other scripts](./2%20Dice%20Game/Syntax.md).

## Guidelines

These guidelines need to be followed when adding and editing content.

### Markdown

All our main lessons are written as `.md` files.\
This will not go over how to write markdown, if you need this please checkout a [guide on the topic](https://guides.github.com/features/mastering-markdown/).\
There are a couple style rules we follow to keep the structure of our work.

#### Headers

`h1`'s are only used once at the top of the file to list the name of unit (I.E. `# 1 Rube Goldberg Machine`).\
Smaller headers should be used to break up sections (I.E. this file) and need to be in sequential order. So an `h4` needs to have an `h3` above it before an `h2`.\
Leave one space between the hashes and the title. Write titles in Upper-Camel-Case with no punctuation. Leave on blank line before and after each header.

```
# Unit Title

Content

## Main Section

More Content

### Sub Section
```

#### New Lines

Split paragraphs into new lines at appropriate sections with a backslash directly after the last character similar to this.`\`\
Do not use double spaces to split lines. You may also leave a blank line with <kbd>Enter</kbd> if you need to split a section but don't need a new header.\
Always add new lines before and after things like lists, images, code blocks, etc.

```
This is some content.\
And my new line of content.

Here is a different idea.
```

#### Code Blocks

When using code blocks always format as csharp ```` ```csharp```` unless you really need not to.\
A couple rules for our code syntax can be found in the [syntax file](./2%20Dice%20Game/Syntax.md). There is not many fancy tricks there.\
Try to avoid repeating large code blocks. If you do skip a part make sure to leave a comment in its place to avoid any confusion for students.\
Use inline code when referring to statements, variables, and the likes.

### Language

The main thing to highlight here is to avoid "I" as much as possible. Use "we".\
When referring to certain parts of the repo the structure is as follows :

* The repo itself is referred to as the "Course".
* The folders within (I.E. the Rube Goldberg Folder) are referred to as a "Unit".
* The files within the units are referred to as "Lessons".
* The final game of each unit is the "Project".

### Structure

To keep our files nice and organized follow the structure of :

* Course
  * Unit
    * Assets
    * Images
    * Library
    * Lesson
    * Lesson
  * Unit
* Course

Where "Images" is a folder for all the images used within the lessons and "Assets" are things the student can use such as a sprite.\
The naming convention for files is :

* Unit : "1 Name Like This"
* Lesson : "1 NameLikeThis"
* Files (I.E. image) : "NameLikeThis"

### References and Links

When mentioning a topic, item, or concept for the first time put it in double quotes ["Like So"](#references-and-links) and make it a link to relevant parts of the course or the C# Docs / Unity Manual. Please also capitalize accordingly.\
After something has been written and linked for the first time you do not need to capitalize and quote it. Only link it again if you are in a new section.\
Do not link things inside of inline code blocks.
