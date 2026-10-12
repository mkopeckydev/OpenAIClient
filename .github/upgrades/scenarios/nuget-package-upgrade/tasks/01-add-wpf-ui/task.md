# 01-add-wpf-ui: Add WPF-UI package

Add the latest stable `WPF-UI` package supported by the project to `src/OpenAIClient/OpenAIClient.csproj`. The assessment found no existing reference, so this is an addition rather than a version upgrade; the resolved package version will be recorded after restore.

## Research findings

- Affected project: `src/OpenAIClient/OpenAIClient.csproj` only.
- The project is SDK-style WPF targeting `net10.0-windows` with `<UseWPF>true</UseWPF>`.
- `get_project_dependencies` found no imported package-management files and no existing package references; use standard per-project `PackageReference` management rather than CPM.
- The project contains XAML (`App.xaml`, `ClientWindow.xaml`), so later validation must use Visual Studio MSBuild guidance for WPF.
- The quick assessment produced no API diff because `WPF-UI` is not currently referenced; compatibility will be verified by NuGet restore/build after adding the package.

**Done when**: The project references `WPF-UI`, restore succeeds, and the resolved package is compatible with `net10.0-windows`.
