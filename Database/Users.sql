
    --Role is created as a controller
    CREATE TABLE roles(
        role_id serial PRIMARY key,
        role_name VARCHAR(100) NOT NULL,
        description TEXT
    );
--ACTIVE INACTIVE SUSPENDED TERMINATED 
    CREATE TABLE status(
        status_id serial PRIMARY KEY,
        status_name VARCHAR(100) NOT NULL,
        description TEXT
    );

    CREATE TABLE users(

        user_id VARCHAR PRIMARY key,

        company_id VARCHAR(150) NOT null,


        first_name VARCHAR(50) NOT NULL,
        last_name VARCHAR(50) NOT NULL,
        email VARCHAR(50) NOT NULL,
       
        password VARCHAR(50) NOT NULL,  
        status_id INTEGER REFERENCES status,   
                   
        created_at TIMESTAMP without time zone,
        modified_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP without time zone,
         primary_contact  VARCHAR(13) NOT NULL,

        UNIQUE(email,company_id)

    );
    CREATE INDEX idx_users_id ON users(user_id);
    CREATE INDEX idx_company_id ON users(company_id);


--When the user logs in and creates their profile
    CREATE TABLE users_profie(


        profile_id serial PRIMARY key,
        user_id VARCHAR REFERENCES users,

        role_id INTEGER REFERENCES roles NOT NULL


    );
