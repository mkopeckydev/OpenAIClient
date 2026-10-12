# NuGet Package Upgrade Plan

## Overview

**Target**: Add the `WPF-UI` NuGet package and configure it as the application-wide default WPF visual style.
**Scope**: One small WPF application targeting `net10.0-windows`, with one main window.

## Tasks

### 01-add-wpf-ui: Add WPF-UI package

Add the latest stable `WPF-UI` package supported by the project to `src/OpenAIClient/OpenAIClient.csproj`. The assessment found no existing reference, so this is an addition rather than a version upgrade; the resolved package version will be recorded after restore.

**Done when**: The project references `WPF-UI`, restore succeeds, and the resolved package is compatible with `net10.0-windows`.

---

### 02-configure-default-theme: Configure application-wide WPF-UI appearance

Configure the WPF-UI theme and control resources in `App.xaml`, initialize the application theme behavior in `App.xaml.cs` as required by the resolved package API, and migrate the existing main window to the WPF-UI window type. The configuration must be inherited by all current and future windows through application resources and a consistent WPF-UI window base/type.

**Done when**: Application resources contain the WPF-UI theme/control dictionaries, the main window uses WPF-UI styling, the default theme is explicitly configured, and the project compiles without XAML or C# warnings.

---

### 03-validate-wpf-ui: Validate WPF-UI integration

Restore and build the project with Visual Studio MSBuild because it is an SDK-style WPF project with XAML. Verify the output assembly and confirm there are no build warnings or errors; run any discovered tests if applicable.

**Done when**: The project and solution build successfully with zero warnings/errors, and test validation is complete or documented as not applicable.
