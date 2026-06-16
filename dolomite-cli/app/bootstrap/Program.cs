using dolomite_cli.app;
using dolomite_cli.app.util;

Logger.Init();
return Logger.Run(() => App.Run());
