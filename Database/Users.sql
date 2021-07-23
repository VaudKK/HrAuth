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