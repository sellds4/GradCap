var gulp = require('gulp');
var jade = require('gulp-jade');
var rename = require('gulp-rename');
var clean = require('gulp-clean');

gulp.task('default', function() {
  // place code for your default task here
});

gulp.task('clean', function() {
    return gulp.src('./GradCap/Static')
    .pipe(clean());
});

gulp.task('cleantemplates', function() {
    return gulp.src(['./client/app/partials', './GradCap/Views/Home/Index.cshtml', './GradCap/Static/app/partials'])
    .pipe(clean());
});

gulp.task('templates', ['cleantemplates'], function() {
    gulp.src('./client/jade/partials/*.jade')
        .pipe(jade({
            pretty: true
        }))
        .pipe(gulp.dest('./client/app/partials'))
        .pipe(gulp.dest('./GradCap/Static/app/partials'))
    gulp.src('./client/jade/index.jade')
        .pipe(jade({
            pretty: true
        }))
        .pipe(gulp.dest('./client/app'))
        .pipe(rename('Index.cshtml'))
        .pipe(gulp.dest('./GradCap/Views/Home'))
});

gulp.task('appdev', ['clean', 'templates'], function() {
    return gulp.src('./client/app/**/*', {
        base: 'client'
    }).pipe(gulp.dest('./GradCap/Static'));
});
