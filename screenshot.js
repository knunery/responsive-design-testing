var page = require('webpage').create(),
    system = require('system'),
    t, address;

if (system.args.length === 1) {
    console.log('Usage: screenshot.js <url> <filename> <width>');
    phantom.exit();
}

var url = system.args[1];
var filename = system.args[2];
var width = system.args[3];

var page = require('webpage').create();

page.viewportSize = { width: width, height:100 }; // height will be automatically adjusted to be the minimum size to fit the entire screen
page.settings.userAgent = "Phantom.js bot";

page.open(url, function () {
    page.render(filename);
    phantom.exit();
});