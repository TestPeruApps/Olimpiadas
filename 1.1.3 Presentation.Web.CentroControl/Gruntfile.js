module.exports = function (grunt) {
    grunt.initConfig({
        clean: {
            lib: [
                "wwwroot/lib/bootstrap/**/*", "!wwwroot/lib/bootstrap/dist/**",
                "wwwroot/lib/bootstrap3-dialog/**/*", "!wwwroot/lib/bootstrap3-dialog/dist/**",
                "wwwroot/lib/bootstrap-datepicker/**/*", "!wwwroot/lib/bootstrap-datepicker/dist/**",
                "wwwroot/lib/bootstrap-datepicker/dist/locales/*", "!wwwroot/lib/bootstrap-datepicker/dist/locales/bootstrap-datepicker.es.min.js",
                "wwwroot/lib/bootstrap-fileinput/**/*", "!wwwroot/lib/bootstrap-fileinput/css/**", "!wwwroot/lib/bootstrap-fileinput/img/**", "!wwwroot/lib/bootstrap-fileinput/js/**",
                "wwwroot/lib/bootstrap-select/**/*", "!wwwroot/lib/bootstrap-select/dist/**",
                "wwwroot/lib/bootstrap-touchspin/**/*", "!wwwroot/lib/bootstrap-touchspin/dist/**",
                "wwwroot/lib/eonasdan-bootstrap-datetimepicker/**/*", "!wwwroot/lib/eonasdan-bootstrap-datetimepicker/build/**", "!wwwroot/lib/eonasdan-bootstrap-datetimepicker/src/**",
                "wwwroot/lib/font-awesome/**/*", "!wwwroot/lib/font-awesome/css/**", "!wwwroot/lib/font-awesome/fonts/**",
                "wwwroot/lib/geocomplete/**/*", "!wwwroot/lib/geocomplete/jquery.geocomplete.js",
                "wwwroot/lib/iCheck/**/*", "!wwwroot/lib/iCheck/icheck.js", "!wwwroot/lib/iCheck/skins/**", "wwwroot/lib/iCheck/skins/**/*", "!wwwroot/lib/iCheck/skins/square/**",
                "wwwroot/lib/cropperjs/**/*", "!wwwroot/lib/cropperjs/dist/**",
                "wwwroot/lib/jquery/**/*", "!wwwroot/lib/jquery/dist/**",
                "wwwroot/lib/jquery.serializeToJSON/**/*", "!wwwroot/lib/jquery.serializeToJSON/dist/**",
                "wwwroot/lib/jquery-ui/**/*", "!wwwroot/lib/jquery-ui/themes/**", "wwwroot/lib/jquery-ui/themes/**/*", "!wwwroot/lib/jquery-ui/themes/base/**", "wwwroot/lib/jquery-ui/themes/base/**/*", "!wwwroot/lib/jquery-ui/themes/base/images/**", "!wwwroot/lib/jquery-ui/themes/base/jquery-ui.css", "!wwwroot/lib/jquery-ui/themes/base/jquery-ui.min.css", "!wwwroot/lib/jquery-ui/jquery-ui.js", "!wwwroot/lib/jquery-ui/jquery-ui.min.js",
                "wwwroot/lib/knockout/**/*", "!wwwroot/lib/knockout/dist/**",
                "wwwroot/lib/bootstrap-colorpicker/**/*", "!wwwroot/lib/bootstrap-colorpicker/dist/**",
                "wwwroot/lib/lightbox2/**/*", "!wwwroot/lib/lightbox2/dist/**",
                "wwwroot/lib/modernizer/**/*", "!wwwroot/lib/modernizer/modernizr.js",
                "wwwroot/lib/moment/**/*", "!wwwroot/lib/moment/min/**", "!wwwroot/lib/moment/locale/**", "wwwroot/lib/moment/locale/*.*", "!wwwroot/lib/moment/locale/es.js",
                "wwwroot/lib/noty/**/*", "!wwwroot/lib/noty/js/**", "wwwroot/lib/noty/js/noty/**/*", "!wwwroot/lib/noty/js/noty/packaged/**",
                "wwwroot/lib/jquery-ui-1.12.1.custom/**/*", "!wwwroot/lib/jquery-ui-1.12.1.custom/jquery-ui.js", "!wwwroot/lib/jquery-ui-1.12.1.custom/leer.docx", "!wwwroot/lib/jquery-ui-1.12.1.custom/images/**"],
            font: ["wwwroot/fonts/*"],
            js: ["wwwroot/js/*.js", "wwwroot/js/forms/*.min.js", "wwwroot/js/helper/*.min.js", "!wwwroot/js/functionNotificacion.es5.min.js"],
            css: ["wwwroot/css/*.css", "wwwroot/css/forms/*.css", "!wwwroot/css/forms/site.temp.css", '!wwwroot/css/forms/site.fonts.css']
        },
        copy: {
            fonts_bootstrap: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/bootstrap/dist/fonts/',
                        src: ['**/*'],
                        dest: 'wwwroot/fonts/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            font_awesome: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/font-awesome/fonts/',
                        src: ['**/*'],
                        dest: 'wwwroot/fonts/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            font_template_hurts: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/templates/hurst-ecommerce-furniture/hurst/fonts/',
                        src: ['**/*'],
                        dest: 'wwwroot/fonts/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            img_bootstrap_fileinput: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/bootstrap-fileinput/img/',
                        src: ['**/*'],
                        dest: 'wwwroot/img/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            img_bootstrap_colorpicker: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/bootstrap-colorpicker/dist/img/bootstrap-colorpicker/',
                        src: ['**/*'],
                        dest: 'wwwroot/img/bootstrap-colorpicker/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            images_jquery_ui: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/jquery-ui-1.12.1.custom/images/',
                        src: ['**/*'],
                        dest: 'wwwroot/images/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            images_lightbox2: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/lightbox2/dist/images/',
                        src: ['**/*'],
                        dest: 'wwwroot/images/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            },
            iCheck_skin: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/lib/iCheck/skins/square/',
                        src: ['blue.png'],
                        dest: 'wwwroot/css/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            }/*,
            js_signalR: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/js/forms/functionNotificacion.js',
                        src: ['functionNotificacion.js'],
                        dest: 'wwwroot/js/',
                        filter: 'isFile',
                        flatten: true
                    }
                ]
            }*/
        },
        uglify: {
            js_shared: {
                options: {                    
                    compress: true,
                    beautify: false, //una sola linea
                    mangle: true //ofusca                    
                },
                src:
                [
                    'wwwroot/lib/jquery/dist/jquery.js',
                    'wwwroot/lib/bootstrap/dist/js/bootstrap.js',
                    'wwwroot/lib/bootstrap3-dialog/dist/js/bootstrap-dialog.js',
                    'wwwroot/lib/formValidation/formValidation.js',
                    'wwwroot/lib/formValidation/Framework.bootstrap.js',
                    'wwwroot/lib/formValidation/i18n.js',
                    'wwwroot/lib/formValidation/mandatoryIcon.js',
                    'wwwroot/lib/formValidation/es_ES.js',                    
                    'wwwroot/lib/noty/js/noty/packaged/jquery.noty.packaged.js',
                    'wwwroot/lib/signalr/dist/browser/signalr.min.js',
                    'wwwroot/js/helper/*.js',
                    '!wwwroot/js/helper/helperConstantes.url.js',
                    'wwwroot/js/forms/app.js',
                    'wwwroot/js/forms/formLogin.js'
                ],
                dest: 'wwwroot/js/shared.min.js'
            },
            js_main: {
                options: {
                    compress: true,
                    beautify: false, //una sola linea
                    mangle: true //ofusca                    
                },
                src:
                [                                        
                    'wwwroot/lib/jquery-ui-1.12.1.custom/jquery-ui.js',
                    'wwwroot/lib/moment/min/moment.min.js',
                    'wwwroot/lib/moment/locale/es.js',
                    'wwwroot/lib/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js',
                    'wwwroot/lib/jquery-mask/dist/jquery.mask.min.js',
                    'wwwroot/lib/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.js',
                    'wwwroot/lib/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js',
                    'wwwroot/lib/bootstrap-fileinput/js/fileinput.js',
                    'wwwroot/lib/bootstrap-fileinput/js/plugins/canvas-to-blob.js',
                    'wwwroot/lib/bootstrap-select/dist/js/bootstrap-select.js',
                    'wwwroot/lib/bootstrap-select/dist/js/i18n/defaults-es_ES.js',                    
                    'wwwroot/lib/cropperjs/dist/cropper.js',
                    'wwwroot/lib/iCheck/icheck.js',
                    'wwwroot/lib/knockout/dist/knockout.js',
                    'wwwroot/lib/jquery.serializeToJSON/dist/jquery.serializeToJSON.js',
                    'wwwroot/lib/geocomplete/jquery.geocomplete.js',
                    'wwwroot/lib/chart.js/dist/Chart.js',
                    'wwwroot/lib/jquery-jvectormap-2.0.3.custom/jquery-jvectormap-2.0.3.min.js',
                    'wwwroot/lib/jquery-jvectormap-2.0.3.custom/jvectormap.peru.js',
                    'wwwroot/lib/lightbox2/dist/js/lightbox.js',
                    'wwwroot/js/forms/*.js',
                    '!wwwroot/js/forms/app.js',
                    '!wwwroot/js/forms/functionNotificacion.js',
                    '!wwwroot/js/forms/formLogin.js'
                ],
                dest: 'wwwroot/js/main.min.js'
            },
            js_zxcvb: {
                options: {                    
                    compress: true,
                    beautify: false, //una sola linea
                    mangle: true //ofusca                    
                },
                src:
                [
                    'wwwroot/lib/zxcvbn.custom.es/dist/zxcvbn.js'
                ],
                dest: 'wwwroot/js/validation.min.js'
            }
        },
        less: {
            development: {
                files: {
                    //'wwwroot/css/forms/site.theme.css': 'wwwroot/css/forms/site.theme.less'
                },
                options: {
                    compress: false
                }
            },
            production_shared_temp: {
                files: {
                    'wwwroot/css/forms/autogenerado.shared.less.css':
                    [
                        'wwwroot/css/forms/site.base.less',
                        'wwwroot/css/forms/site.skin.less'
                    ]
                },
                options: {
                    compress: true,
                    autoPrefix: "",
                    ieCompat: true,
                    strictMath: false,
                    strictUnits: false,
                    relativeUrls: true,
                    rootPath: "",
                    sourceMapRoot: "",
                    sourceMapBasePath: "",
                    sourceMap: false
                }
            },
            production_login_temp: {
                files: {
                    'wwwroot/css/forms/autogenerado.login.less.css':
                    [
                            'wwwroot/css/forms/layout.login.less'                            
                    ]
                },
                options: {
                    compress: true,
                    autoPrefix: "",
                    ieCompat: true,
                    strictMath: false,
                    strictUnits: false,
                    relativeUrls: true,
                    rootPath: "",
                    sourceMapRoot: "",
                    sourceMapBasePath: "",
                    sourceMap: false
                }
            },
            production_main_temp: {
                files: {
                    'wwwroot/css/forms/autogenerado.main.less.css':
                    [
                        'wwwroot/css/forms/*.less',
                        '!wwwroot/css/forms/site.base.less',
                        '!wwwroot/css/forms/site.skin.less',
                        '!wwwroot/css/forms/layout.login.less',
                        '!wwwroot/css/forms/form.verMapa.less'
                    ]
                },
                options: {
                    compress: true,
                    autoPrefix: "",
                    ieCompat: true,
                    strictMath: false,
                    strictUnits: false,
                    relativeUrls: true,
                    rootPath: "",
                    sourceMapRoot: "",
                    sourceMapBasePath: "",
                    sourceMap: false
                }
            }
        },
        purifycss: {//Ya deben estar creados el js final (wwwroot/js/*.js) y el css de los LESS (wwwroot/css/forms/forms.css)
            css_shared: {
                options: {
                    minify: true,
                    info: true
                },
                src: [
                    'Areas/**/Views/**/*.cshtml',
                    'Views/**/*.cshtml',
                    'wwwroot/js/*.js'
                ],
                css: [                    
                    'wwwroot/css/forms/site.fonts.css',
                    'wwwroot/lib/bootstrap/dist/css/bootstrap.min.css',
                    'wwwroot/lib/font-awesome/css/font-awesome.min.css',
                    'wwwroot/css/forms/autogenerado.shared.less.css',
                    'wwwroot/css/forms/site.temp.css'
                ],
                dest: 'wwwroot/css/shared.min.css'
            },
            css_login: {
                options: {
                    minify: true,
                    info: true
                },
                src: [
                    'Areas/**/Views/**/*.cshtml',
                    'Views/**/*.cshtml',
                    'wwwroot/js/*.js'
                ],
                css: [
                    'wwwroot/css/forms/autogenerado.login.less.css'
                ],
                dest: 'wwwroot/css/login.min.css'
            },
            css_main: {
                options: {
                    minify: true,
                    info: true
                },
                src: [
                    'Areas/**/Views/**/*.cshtml',
                    'Views/**/*.cshtml',
                    'wwwroot/js/*.js'
                ],
                css: [
                    'wwwroot/lib/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.css',
                    'wwwroot/lib/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css',
                    'wwwroot/lib/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css',
                    'wwwroot/lib/jquery-ui/themes/base/jquery-ui.css',                    
                    'wwwroot/lib/iCheck/skins/square/blue.css',
                    "wwwroot/lib/bootstrap-fileinput/css/fileinput.css",
                    "wwwroot/lib/bootstrap-select/dist/css/bootstrap-select.css",                    
                    "wwwroot/lib/jquery-jvectormap-2.0.3.custom/jquery-jvectormap-2.0.3.css",
                    "wwwroot/lib/lightbox2/dist/css/lightbox.css",
                    "wwwroot/lib/cropperjs/dist/cropper.css",
                    "wwwroot/css/forms/autogenerado.main.less.css"
                ],
                dest: 'wwwroot/css/main.min.css'
            }
        },
        concat: {
            js_bundle: {
                src: ['wwwroot/lib/jquery/dist/jquery.min.js',
                    'wwwroot/lib/bootstrap/dist/js/bootstrap.min.js'],
                dest: 'wwwroot/js/bundle.js'
            },
            css_bundle: {
                src: ['wwwroot/lib/bootstrap/dist/css/bootstrap.min.css',
                    'wwwroot/lib/bootstrap/dist/css/bootstrap-theme.min.css',
                    'wwwroot/lib/font-awesome/css/font-awesome.min.css'],
                dest: 'wwwroot/css/bundle.css'
            },
            css_site: {
                src: ['wwwroot/css/forms/*.css', '!wwwroot/css/forms/*.min.css'],
                dest: 'wwwroot/css/forms/site.css'
            }
        },
        cssmin: {
            css_bundle: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/css',
                        src: ['*.css', '!*.min.css'],
                        dest: 'wwwroot/css',
                        ext: '.min.css'
                    }
                ]
            },
            css_site: {
                files: [
                    {
                        expand: true,
                        cwd: 'wwwroot/css/forms',
                        src: ['*.css', '!*.min.css'],
                        dest: 'wwwroot/css/forms',
                        ext: '.min.css'
                    }
                ]
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-less');
    //grunt.loadNpmTasks('grunt-contrib-concat');
    //grunt.loadNpmTasks('grunt-contrib-jshint');    
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-copy');
    //grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-purifycss');
    //--- con error grunt.registerTask("Production", ['clean:font', 'clean:js', 'clean:css', 'copy', 'uglify:js_shared', 'uglify:js_main', 'uglify:js_zxcvb', 'less:production_shared_temp', 'less:production_login_temp', 'less:production_main_temp', 'purifycss']);
    grunt.registerTask("Production", ['clean:font', 'clean:js', 'clean:css', 'copy', 'uglify:js_shared', 'uglify:js_main', 'less:production_shared_temp', 'less:production_login_temp', 'less:production_main_temp', 'purifycss']);
};