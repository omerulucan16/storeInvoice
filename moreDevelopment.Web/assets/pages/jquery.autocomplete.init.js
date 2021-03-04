/**
* Theme: Highdmin - Responsive Bootstrap 4 Admin Dashboard
* Author: Coderthemes
* Auto Complete
*/


/*jslint  browser: true, white: true, plusplus: true */
/*global $, countries */

var products = {};
$.ajax({
    type: "GET",
    url: 'urun/urun-listesi',
    data: "check",
    success: function (data) {
        debugger;
        products = data.productList;
        $(function () {
            'use strict';
            var productsArray = {};
            setTimeout(function () {

            }, 3000);
            productsArray = $.map(products, function (value, key) { return { value: value.Name, data: value }; });

            // Setup jQuery ajax mock:


            // Initialize ajax autocomplete:
            $('#autocomplete-ajax').autocomplete({
                // serviceUrl: '/autosuggest/service/url',
                lookup: productsArray,
                lookupFilter: function (suggestion, originalQuery, queryLowerCase) {
                 
                    if (suggestion.value == originalQuery || suggestion.value.indexOf(originalQuery) != -1)
                        return true;
                    else
                        return false;
                },
                onSelect: function (suggestion) {
                    this.results={
                        "value": suggestion.value,
                        "data": suggestion.data
                    };
                    $('#selction-ajax').html('You selected: ' + suggestion.value + ', ' + suggestion.data);
                },
                onHint: function (hint) {
                    $('#autocomplete-ajax-x').val(hint);
                },
                onInvalidateSelection: function () {
                    $('#selction-ajax').html('You selected: none');
                }
            });

            var nhlTeams = ['Anaheim Ducks', 'Atlanta Thrashers', 'Boston Bruins', 'Buffalo Sabres', 'Calgary Flames', 'Carolina Hurricanes', 'Chicago Blackhawks', 'Colorado Avalanche', 'Columbus Blue Jackets', 'Dallas Stars', 'Detroit Red Wings', 'Edmonton OIlers', 'Florida Panthers', 'Los Angeles Kings', 'Minnesota Wild', 'Montreal Canadiens', 'Nashville Predators', 'New Jersey Devils', 'New Rork Islanders', 'New York Rangers', 'Ottawa Senators', 'Philadelphia Flyers', 'Phoenix Coyotes', 'Pittsburgh Penguins', 'Saint Louis Blues', 'San Jose Sharks', 'Tampa Bay Lightning', 'Toronto Maple Leafs', 'Vancouver Canucks', 'Washington Capitals'];
            var nbaTeams = ['Atlanta Hawks', 'Boston Celtics', 'Charlotte Bobcats', 'Chicago Bulls', 'Cleveland Cavaliers', 'Dallas Mavericks', 'Denver Nuggets', 'Detroit Pistons', 'Golden State Warriors', 'Houston Rockets', 'Indiana Pacers', 'LA Clippers', 'LA Lakers', 'Memphis Grizzlies', 'Miami Heat', 'Milwaukee Bucks', 'Minnesota Timberwolves', 'New Jersey Nets', 'New Orleans Hornets', 'New York Knicks', 'Oklahoma City Thunder', 'Orlando Magic', 'Philadelphia Sixers', 'Phoenix Suns', 'Portland Trail Blazers', 'Sacramento Kings', 'San Antonio Spurs', 'Toronto Raptors', 'Utah Jazz', 'Washington Wizards'];
            var nhl = $.map(nhlTeams, function (team) { return { value: team, data: { category: 'NHL' } }; });
            var nba = $.map(nbaTeams, function (team) { return { value: team, data: { category: 'NBA' } }; });
            var teams = nhl.concat(nba);

            // Initialize autocomplete with local lookup:
            $('#autocomplete').devbridgeAutocomplete({
                lookup: teams,
                minChars: 1,
                onSelect: function (suggestion) {
                    $('#selection').html('You selected: ' + suggestion.value + ', ' + suggestion.data.category);
                },
                showNoSuggestionNotice: true,
                noSuggestionNotice: 'Sorry, no matching results',
                groupBy: 'category'
            });

            // Initialize autocomplete with custom appendTo:
            $('#autocomplete-custom-append').autocomplete({
                lookup: productsArray,
                appendTo: '#suggestions-container'
            });

            // Initialize autocomplete with custom appendTo:
            $('#autocomplete-dynamic').autocomplete({
                lookup: productsArray
            });
        });
        debugger;
    }
});
