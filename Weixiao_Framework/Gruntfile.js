//grunt配置
module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["temp/"],
        concat: {
            all: {
                src: ['TypeScript/Tastes.js', 'TypeScript/Food.js'],
                dest: 'temp/combined.js'
            }
        }, jshint: {
            files: ['temp/*.js'],
          /*  options: {
                '-W069': false,
            }*/
        }, uglify: {
            all: {
                src: ['temp/combined.js'],
                dest: 'temp/combined.min.js'
            }
        },
    });
    //删除文件
    grunt.loadNpmTasks("grunt-contrib-clean");
    //Ts生成js
    grunt.loadNpmTasks("grunt-contrib-concat");
    //代码检查
    grunt.loadNpmTasks("grunt-contrib-jshint");
    //压缩文件
    grunt.loadNpmTasks('grunt-contrib-uglify');

    grunt.registerTask("all", ['clean', 'concat', 'jshint', 'uglify']);
};