(function () {
    jQuery.showMessage = function (message, options) {
        // defaults
        settings = jQuery.extend({
            id: 'sliding_message_box',
            position: 'bottom',
            size: '50',
            border_bottom_width: '0px',
            border_bottom_color: '',
            border_bottom_style: 'close',
            backgroundColor: '#35496A',
            color: 'white',
            width: '350px',
            delay: 2600,
            speed: 800,
            fontSize: '18px'
        }, options);

        var elem = $('#' + settings.id);
        var delayed;

        // generate message div if it doesn't exist
        if (elem.length == 0) {
            elem = $('<div></div>').attr('id', settings.id);


            if (settings.position == 'top') {
                elem.css({ 'z-index': '999',
                    'background-color': settings.backgroundColor,
                 
                    'text-align': 'center',
                    'position': 'absolute',
                    'position': 'fixed',
                    'border-bottom-width': settings.border_bottom_width,
                    'border-bottom-style': settings.border_bottom_style,
                    'border-bottom-color': settings.border_bottom_color,

                    'border-bottom-left-radius': '10px',
                    'border-bottom-right-radius': '10px',
                    '-moz-border-bottom-left-radius': '10px',
                    '-moz-border-bottom-right-radius': '10px',
                    '-webkit-border-bottom-left-radius': '10px',
                    '-webkit-border-bottom-right-radius': '10px',

                    'left': '0',
                    'color': settings.color, //'#FFFFFF',
                    'width': settings.width, //'350px',
                    'line-height': settings.size + 'px',
                    'font-size': settings.fontSize
                });
            }
            else {
             elem.css({ 'z-index': '999',
                 'background-color': settings.backgroundColor,
         
                    'text-align': 'center',
                    'position': 'absolute',
                    'position': 'fixed',
                    'border-top-width': settings.border_bottom_width,
                    'border-top-style': settings.border_bottom_style,
                    'border-top-color': settings.border_bottom_color,

                    'border-top-left-radius': '10px',
                    'border-top-right-radius': '10px',
                    '-moz-border-top-left-radius': '10px',
                    '-moz-border-top-right-radius': '10px',
                    '-webkit-border-top-left-radius': '10px',
                    '-webkit-border-top-right-radius': '10px',

                    'left': '0',
                    'color': settings.color, //'#FFFFFF',
                    'width': settings.width, //'350px',
                    'line-height': settings.size + 'px',
                    'font-size': settings.fontSize
                });
            }

            $('body').append(elem);
        }

        elem.html(message);

        if (settings.position == 'bottom') {
            elem.css('bottom', '-' + settings.size + 'px');
            elem.animate({ bottom: '0' }, settings.speed);
            delayed = '$("#' + settings.id + '").animate({bottom:"-' + settings.size + 'px"}, ' + settings.speed + ');';
            setTimeout(delayed, settings.delay);
        }
        else if (settings.position == 'top') {
            elem.css('top', '-' + settings.size + 'px');
            elem.animate({ top: '0' }, settings.speed);
            delayed = '$("#' + settings.id + '").animate({top:"-' + settings.size + 'px"}, ' + settings.speed + ');';
            setTimeout(delayed, settings.delay);
        }
    }
})(jQuery);

