using dolomite_cli.App;
using dolomite_cli.App.Util;

Logger.Init();
return Logger.Run(() => App.Run());
