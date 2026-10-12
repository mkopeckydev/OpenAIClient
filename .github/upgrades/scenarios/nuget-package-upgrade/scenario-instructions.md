# NuGet Package Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Scope**: Solution `src/OpenAIClient.slnx`
- **Package**: `WPF-UI`
- **Version Policy**: Latest supported stable version for `.NET 10`
- **Commit Strategy**: After Each Task

## Source Control
- **Source Branch**: main
- **Working Branch**: upgrade-nuget-wpf-ui
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Decisions
- Configure WPF-UI as the default visual theme for all WPF windows in the application.
