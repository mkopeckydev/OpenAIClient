# 02-configure-default-theme: Configure application-wide WPF-UI appearance

Configure the WPF-UI theme and control resources in `App.xaml`, initialize the application theme behavior in `App.xaml.cs` as required by the resolved package API, and migrate the existing main window to the WPF-UI window type. The configuration must be inherited by all current and future windows through application resources and a consistent WPF-UI window base/type.

**Done when**: Application resources contain the WPF-UI theme/control dictionaries, the main window uses WPF-UI styling, the default theme is explicitly configured, and the project compiles without XAML or C# warnings.
