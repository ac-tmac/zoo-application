//
// include plugins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var copy = require('gulp-copy');
var bower = require('gulp-bower');
var sourcemaps = require('gulp-sourcemaps');

var config = {
    //Modernizr
    angularsrc: ['bower_components/angular/angular.js'],
    angularbundle: 'Scripts/angular.min.js',
}

// Synchronously delete the output script file(s)
gulp.task('clean-vendor-scripts', function (cb) {
    del([config.angularbundle], cb);
});

//Create a modernizr bundled file
gulp.task('angular', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.angularsrc)
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(concat('angular-min.js'))
        .pipe(sourcemaps.write('maps'))
        .pipe(gulp.dest('Scripts'));
});

// Combine and the vendor files from bower into bundles (output to the Scripts folder)
gulp.task('vendor-scripts', ['angular'], function () {

});

//Restore all bower packages
gulp.task('bower-restore', function () {
    return bower();
});

//Set a default tasks
gulp.task('default', ['vendor-scripts'], function () {

});