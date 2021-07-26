CREATE TABLE org(
    org_id serial PRIMARY key,
    org_name VARCHAR(100) NOT NULL,
    org_email VARCHAR(100) NOT NULL,
    org_address VARCHAR(100) NOT NULL,
    org_primary_contract VARCHAR(100) NOT NULL,
    org_creater VARCHAR(100) REFERENCES users,
    org_createion_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);