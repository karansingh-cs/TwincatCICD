# SCADA HMI Starter (WPF)

This workspace now includes a WPF HMI project at `ScadaHmi/` with:
- Dashboard view (connection, process values, controls, alarms)
- MVVM structure (`ViewModels`, `Services`, `Models`, `Commands`)
- PLC abstraction via `IPlcService`
- `MockPlcService` for offline UI testing

## Wire to TwinCAT ADS

1. Add NuGet package `Beckhoff.TwinCAT.Ads` to `ScadaHmi.csproj`.
2. Create `AdsPlcService : IPlcService` in `ScadaHmi/Services`.
3. Map your PLC symbols in `ReadSnapshot()`:
- `MAIN.bIsConnected` (or infer from connection state)
- `MAIN.nPumpSpeedRpm`
- `MAIN.nTankLevelPercent`
- `MAIN.bAutoMode`
4. Replace `new MockPlcService()` in `MainWindow.xaml.cs` with `new AdsPlcService(...)`.

## Suggested next HMI pages
- Trend chart for process values
- Alarm acknowledge flow
- Manual setpoint entry with role-based access
- Recipe page for machine modes
