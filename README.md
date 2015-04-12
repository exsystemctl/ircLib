#ircLib

A simple way to connect and interact with the internet relay chat network.

## Installation

Simply add a reference to `ircLib.dll` in your project.

## Usage

* `ircLib.ircLib.Connect(server address, port, channel name, nickname, optional password);` -- Will connect to a server
* `ircLib.ircLib.sendMessage(message);` -- Will send a message to the connected channel
* `ircLib.ircLib.getOutput();` -- Will return current line of output. Useful in while loops.

## Examples

```c#
ircLib.ircLib.Connect("asimov.freenode.net", 6667, "sysCHAT", "OG Gangsta");
ircLib.ircLib.sendMessage("heyo!");

while (true){
  Console.WriteLine(ircLib.ircLib.getOutput());
}
```

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D


## License

This project is licensed under the terms of the GNU license.
