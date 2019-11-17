CREATE TABLE  user_table
(
    id              BIGSERIAL                  PRIMARY KEY,
    login           TEXT                       NOT NULL UNIQUE,
    firstName       TEXT                       NOT NULL UNIQUE,
    lastName        TEXT                       NOT NULL UNIQUE,
    middleName      TEXT                       NOT NULL UNIQUE,
    password        TEXT                       NOT NULL,
    email           TEXT                       NOT NULL UNIQUE,
    birthDate       TIMESTAMPTZ                NOT NULL
);

CREATE TABLE critic_table
(
    id              BIGSERIAL                  PRIMARY KEY,
    login           TEXT                       NOT NULL UNIQUE,
    password        TEXT                       NOT NULL,
    email           TEXT                       NOT NULL UNIQUE,
    isAdmin         BOOLEAN DEFAULT FALSE      NOT NULL
);


CREATE TABLE message_table
(
    id              BIGSERIAL                  PRIMARY KEY,
    user_id         BIGINT  REFERENCES user_table(id) NOT NULL,
    msg             TEXT                       NOT NULL,
    created         TIMESTAMPTZ DEFAULT NOW()  NOT NULL,
    seen            BOOLEAN DEFAULT FALSE      NOT NULL
);

CREATE TABLE review_request
(
    id              BIGSERIAL                  PRIMARY KEY,
    user_id         BIGINT  REFERENCES user_table(id) NOT NULL,
    created         TIMESTAMPTZ DEFAULT NOW()  NOT NULL,
    isReview        BOOLEAN DEFAULT FALSE      NOT NULL,
    reviewFilm      TEXT                       NOT NULL,
    ratingFilm      SMALLINT                   NOT NULL,
    review          TEXT                       NOT NULL
)

CREATE TABLE review
(
    id              BIGSERIAL                  PRIMARY KEY,
    request_id      BIGINT  REFERENCES review_request(id) NOT NULL,
    user_id         BIGINT  REFERENCES user_table(id) NOT NULL,
    created         TIMESTAMPTZ DEFAULT NOW()  NOT NULL
)


CREATE TABLE user_log
(
    id              BIGSERIAL                  PRIMARY KEY,
    created         TIMESTAMPTZ DEFAULT NOW()  NOT NULL,
    user_id         BIGINT                     REFERENCES user_table (id) ON UPDATE CASCADE ON DELETE CASCADE NOT NULL,
    log             TEXT                       NOT NULL
);