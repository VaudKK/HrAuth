    CREATE TABLE users(

        user_id serial PRIMARY key,

        company_id VARCHAR(150) NOT null,


        first_name VARCHAR(50) NOT NULL,
        last_name VARCHAR(50) NOT NULL,
        email VARCHAR(50) NOT NULL,
        primary_contact  VARCHAR(13) NOT NUL,

        password VARCHAR(50) NOT NULL,    
                   
        created_at DATE not null default CURRENT_DATE,
        modified_at  DATE 
        

    );
    CREATE INDEX idx_users_id ON users(user_id);
    CREATE INDEX idx_company_id ON users(company_id);

    --Role is created as a controller
    CREATE TABLE roles(
        role_id serial PRIMARY key,
        role_name VARCHAR(100) NOT NULL,
        description TEXT
    );

--When the user logs in and creates their profile
    CREATE TABLE users_profie(


        profile_id serial PRIMARY key,
        user_id REFERENCES users,

        role_id REFERENCES roles NOT NULL,


    );