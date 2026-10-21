# GitHub Copilot Instructions for Anima Tree reskin (Continued) Mod

## Overview and Purpose
The "Anima Tree reskin (Continued)" mod is an updated version of Cattleya's original mod for RimWorld. This project focuses on reskinning the Anima Tree and introduces a new building, the Anima Tree Spot. The update replaces the incident overwrite with a patch, ensuring better mod compatibility and integration.

## Key Features and Systems

- **Anima Tree Spot**: Introduces a new building, the Anima Tree Spot. It creates an ornament on the ground designed to attract the Anima Tree. This structure must be placed outdoors and without a roof to function correctly. The proximity of other buildings to the Spot reduces the tree’s potential.

- **Reskinning**: Provides a new visual aesthetic for the Anima Tree, enhancing the game’s visual experience.

- **Mod Compatibility**: The update uses Harmony patches instead of overwrites, allowing compatibility with other mods seamlessly, like the Hardcore SK mod pack.

- **Error Reporting and Support**: Users are encouraged to report issues via the Discord channel and use the Log Uploader for error tracking. Feedback is welcome, and solutions to issues should be shared on the GitHub repository.

## Coding Patterns and Conventions

- **Use of Harmony Patches**: The mod uses Harmony library to patch existing game functions. This ensures that the mod does not conflict with others by avoiding direct overwrites of game code.

- **C# Structure**: The mod maintains a consistent structure with separate C# files for each major class and functions such as `AnimaTreeReskin_Mod`, `AnimaTreeReskin_IncidentWorker_AnimaTreeSpawn`, and `AnimaTreeSpot`.

- **XML Definitions**: XML files are used extensively to define game objects and incidents. These include ThingDefs for buildings, and IncidentDefs for spawning events, ensuring clear separation between game logic and content specification.

## XML Integration

- **File Structure**: 
  - Game objects and incidents are defined in XML files located under /Defs/ and /IncidentDefs/.
  - Translations and patches are maintained in /TranslationTemplate/ and /Patches/ directories, respectively.

- **XML Usage**: 
  - `ThingDefs` are used for defining new buildings like the Anima Tree Spot.
  - `IncidentDefs` and `letterDef` specify the detail of custom incident logic.

## Harmony Patching

- **Implementation**: 
  - Ensure that the mod uses `HarmonyLib` to safely apply patches to the existing game logic, thus eliminating conflicts and retaining compatibility with the core game.
  
- **Application**: 
  - Methods such as `Prefix` in files like `Designator_AreaBuildRoof_DesignateSingleCell.cs` are prefixed to existing game methods for modifying behavior without outright replacement.

## Suggestions for Copilot

- **Variable Naming**: Ensure all variables and methods are meaningfully named to reflect their purpose within the mod, which aids in Copilot's capability to provide relevant suggestions.

- **Commenting**: Maintain thorough inline comments and method summarizations in your code. This assists Copilot in understanding the context and improves its capability to suggest accurate code snippets.

- **Modular Code**: Write modular and reusable components. Copilot excels at pattern recognition and will better assist when reusable and clear patterns are established.

- **XML Consistency**: Maintain consistent syntax and tag usage in XML files to help Copilot identify and suggest appropriate XML completion and corrections.

- **Error Handling**: Implement clear error handling mechanisms and logging within the mod’s C# files to aid debugging. This structure assists Copilot in providing suggestions for forming robust error checking logic.

This document should serve as a comprehensive guideline for managing and expanding "Anima Tree reskin (Continued)" while leveraging GitHub Copilot for effective development.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

