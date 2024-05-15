FROM postgres:latest

# Copy the initialization script into the image
COPY ./postgres/init-db.sh /docker-entrypoint-initdb.d/

# Ensure the script is executable
RUN chmod +x /docker-entrypoint-initdb.d/init-db.sh