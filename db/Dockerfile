FROM mysql:5.7.22
EXPOSE 3306
CPY ./Product.ApiRest/ /home/database
CPY ./Product.ApiRest/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh