/*
* jQuery pager plugin
* Version 1.0 (12/22/2008)
* @requires jQuery v1.2.6 or later
*
* Example at: http://jonpauldavies.github.com/JQuery/Pager/PagerDemo.html
*
* Copyright (c) 2008-2009 Jon Paul Davies
* Dual licensed under the MIT and GPL licenses:
* http://www.opensource.org/licenses/mit-license.php
* http://www.gnu.org/licenses/gpl.html
* 
* Read the related blog post and contact the author at http://www.j-dee.com/2008/12/22/jquery-pager-plugin/
*
* This version is far from perfect and doesn't manage it's own state, therefore contributions are more than welcome!
*
* Usage: .pager({ pagenumber: 1, pagecount: 15, buttonClickCallback: PagerClickTest });
*
* Where pagenumber is the visible page number
*       pagecount is the total number of pages to display
*       buttonClickCallback is the method to fire when a pager button is clicked.
*
* buttonClickCallback signiture is PagerClickTest = function(pageclickednumber) 
* Where pageclickednumber is the number of the page clicked in the control.
*
* The included Pager.CSS file is a dependancy but can obviously tweaked to your wishes
* Tested in IE6 IE7 Firefox & Safari. Any browser strangeness, please report.
*/
(function ($) {
    $.fn.pager = function (options) {
        var opts = $.extend({}, $.fn.pager.defaults, options);

        return this.each(function () {
            if (options.endPoint == undefined) {
                options.endPoint = 5;
            }
            if (options.thisPage == undefined) {
                options.thisPage = "true";
            }
            if (options.showEnd == undefined) {
                options.showEnd = "true";
            }
            if (options.showNext == undefined) {
                options.showNext = "true";
            }
            $(this).empty().append(renderpager(parseInt(options.pagenumber), parseInt(options.pagecount), parseInt(options.endPoint), options.showNext, options.showEnd, options.thisPage, options.buttonClickCallback));
            $(".pages li").mouseover(function () {
                document.body.style.cursor = "pointer";
            }).mouseout(function () {
                document.body.style.cursor = "auto";
            });
        });
    };
    function renderpager(pagenumber, pagecount, endPoint, showNext, showEnd, thisPage, buttonClickCallback) {
        var $pager = $("<div class=\"pages\"></div>");

        var startPoint = 1;
        var temp = 2;
        switch (endPoint) {
            case 3:
                temp = 1;
                break;
            case 5:
                temp = 2;
                break;
            case 7:
                temp = 3;
                break;
            case 9:
                temp = 4;
                break;
            case 11:
                temp = 5;
                break;
            case 13:
                temp = 6;
                break;
            case 15:
                temp = 7;
                break;
        }
        if (pagenumber > temp) {
            startPoint = pagenumber - temp;
            endPoint = pagenumber + temp;
        }
        if (endPoint > pagecount) {
            startPoint = pagecount - (temp * 2);
            endPoint = pagecount;
        }
        if (startPoint < 1) {
            startPoint = 1;
        }
        if (showNext == "true") {
            $pager.append(renderButton(WebLang.Prev, pagenumber, pagecount, buttonClickCallback, startPoint, endPoint));
        }
        if (showEnd == "true") {
            $pager.append(renderButton("1...", pagenumber, pagecount, buttonClickCallback, startPoint, endPoint));
        }
        for (var page = startPoint; page <= endPoint; page++) {
            var currentButton = $("<a href=\"javascript:;\" class=\"page-number\">" + (page) + "</a>");
            page == pagenumber ? currentButton.addClass("pgCurrent") : currentButton.click(function () {
                buttonClickCallback(this.firstChild.data);
            });
            currentButton.appendTo($pager);
        }
        if (showEnd == "true") {
            $pager.append(renderButton("..." + pagecount, pagenumber, pagecount, buttonClickCallback, startPoint, endPoint));
        }
        if (showNext == "true") {
            $pager.append(renderButton(WebLang.Next, pagenumber, pagecount, buttonClickCallback, startPoint, endPoint));
        }
        if (thisPage != "false") {
            var span = $("<span class='pageCount'>" + pagenumber + "/" + pagecount + "</span>");
            $pager.append(span);
        }
        return $pager;
    }
    function renderButton(buttonLabel, pagenumber, pagecount, buttonClickCallback, startPoint, endPoint) {
        var $Button = $("<a href=\"javascript:;\" class=\"pgNext\">" + buttonLabel + "</a>");
        var destPage = 1;

        if (buttonLabel.indexOf('...') != -1) {
            destPage = buttonLabel.replace("...", "");
            if (destPage == startPoint || destPage == endPoint)
            { $Button.addClass("pgEmpty"); }
            if (destPage == startPoint - 1 || destPage == endPoint + 1)
            { $Button.html(destPage); }
        }
        else {
            switch (buttonLabel) {
                case WebLang.First:
                    destPage = 1;
                    break;
                case WebLang.Prev:
                    destPage = pagenumber - 1;
                    break;
                case WebLang.Next:
                    destPage = pagenumber + 1;
                    break;
                case WebLang.Last:
                    destPage = pagecount;
                    break;
            }
        }
        if (buttonLabel == "1..." || buttonLabel == WebLang.First || buttonLabel == WebLang.Prev) {
            pagenumber <= 1 ? $Button.addClass("pgEmpty") : $Button.click(function () {
                buttonClickCallback(destPage);
            });
        } else {
            pagenumber >= pagecount ? $Button.addClass("pgEmpty") : $Button.click(function () {
                buttonClickCallback(destPage);
            });
        }
        return $Button;
    }
    $.fn.pager.defaults = { pagenumber: 1, pagecount: 1, endPoint: 9 };
})(jQuery);


